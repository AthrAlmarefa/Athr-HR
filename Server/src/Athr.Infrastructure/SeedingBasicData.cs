using Athr.Domain.BusinessRoles;
using Athr.Domain.Categories;
using Athr.Domain.Common;
using Athr.Domain.Countries;
using Athr.Domain.Enumerations;
using Athr.Domain.Permissions;
using Athr.Domain.Users.Authorization;
using Athr.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using Athr.Application.Abstractions.Behaviors;
using Athr.Domain.Qualification;

namespace Athr.Infrastructure
{
    public static class SeedingBasicData
    {

        private static AccountId _adminRoleId = AccountId.CreateUnique();
        private static AccountId _instructorRoleId = AccountId.CreateUnique();
        private static AccountId _parentRoleId = AccountId.CreateUnique();
        private static AccountId _studentRoleId = AccountId.CreateUnique();

        private readonly static IEnumerable<Permission> seedPermission = SeedPermission();

        public static async Task SeedDataAsync(ApplicationDbContext db)
        {
            try
            {
                if (!await db.Set<BusinessRole>().AnyAsync())
                {
                    db.Set<BusinessRole>().AddRange(SeedRoles());
                    Console.WriteLine("Database seeded with roles.");
                }

                if (!await db.Set<Permission>().AnyAsync())
                {
                    db.Set<Permission>().AddRange(seedPermission);
                    Console.WriteLine("Database seeded with permissions.");
                }

                if (!await db.Set<Country>().AnyAsync())
                {
                    db.Set<Country>().AddRange(await SeedCountries());
                    Console.WriteLine("Database seeded with Countries.");
                }

                if (!await db.Set<Qualification>().AnyAsync())
                {
                    db.Set<Qualification>().AddRange(SeedQualifications());
                    Console.WriteLine("Database seeded with Qualifications.");
                }

                if (!await db.Set<UserEntity>().AnyAsync())
                {
                    db.Set<UserEntity>().AddRange(SeedAdmins());
                    Console.WriteLine("Database seeded with admins.");
                }

                if (!await db.Set<Category>().AnyAsync())
                {
                    db.Set<Category>().AddRange(SeedCategories());
                    Console.WriteLine("Database seeded with categories.");
                }
                db.SaveChanges();
                Console.WriteLine("Database seeding completed Successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(SeedingBasicData)} get Error: \n {ex.Message}");
            }
            finally
            {
                db?.Dispose();
            }
        }

        private static IEnumerable<BusinessRole> SeedRoles()
        {
            var adminRole = BusinessRole.CreateInstance(_adminRoleId, "Management", "Admin", true);
            
            adminRole.ChangeAllowedPermissions(GetAdminPermissions().Select(p => AllowedPermission.Create(p.PermissionId, p.Name)));
            
            //adminRole.ChangeAllowedPermissions(GetAdminPermissions().Select(p => AllowedPermission.Create(p.PermissionId, p.Name)));

            BusinessRole[] roles =
            new[] {
                adminRole
            };
            return roles;
        }

        private static IEnumerable<Permission> SeedPermission()
        {
            var permissions = new[]
            {
                // User Management
                Permission.Create(Guid.NewGuid(), "user.edit", ["User", "Management"], "user.edit", true, true),
                Permission.Create(Guid.NewGuid(), "user.activate", ["User", "Management"], "user.activate", true, true),

                // Admin Management
                Permission.Create(Guid.NewGuid(), "admin.index", ["Admin", "Management"], "admin.index", true, true),
                Permission.Create(Guid.NewGuid(), "admin.view", ["Admin", "Read"], "admin.view", true, true),
                Permission.Create(Guid.NewGuid(), "admin.create", ["Admin", "Management"], "admin.create", true),
                Permission.Create(Guid.NewGuid(), "admin.edit", ["Admin", "Management"], "admin.edit", true, false),
                Permission.Create(Guid.NewGuid(), "admin.delete", ["Admin", "Management"], "admin.delete", true, false),

                // Category Management
                Permission.Create(Guid.NewGuid(), "category.index", ["Category", "Management"], "category.index", true, true),
                Permission.Create(Guid.NewGuid(), "category.view", ["Category", "Read"], "category.view", true, true),
                Permission.Create(Guid.NewGuid(), "category.create", ["Category", "Management"], "category.create", true),
                Permission.Create(Guid.NewGuid(), "category.edit", ["Category", "Management"], "category.edit", true, false),
                Permission.Create(Guid.NewGuid(), "category.delete", ["Category", "Management"], "category.delete", true, false),

                Permission.Create(new Guid("C42BB008-D948-4424-9EE2-BA37C13D0182"),
                    "business.define-allowed-permissions", ["Business", "Instructor", "Permissions", "Security"]
                    , "business.define-allowed-permissions",
                    true),

                Permission.Create(new Guid("374CA149-E28D-4230-9C37-760E65D1DFC9"),
                    "instructor.assign-permissions", ["Business", "Instructor", "Permissions", "Security"]
                    , "instructor.assign-permissions",
                    true),
            };
            Console.WriteLine($"Permissions 1 => {permissions.First().Id.Value}");
            return permissions;
        }

        private static IEnumerable<UserEntity> SeedAdmins()
        {
            // System Administrator
            var admin = UserEntity.CreateInstance(
                FirstName: "Admin",
                MidName: "System",
                LastName: "Administrator",
                Email: "admin@admin.athr.edu",
                PhoneNumber: "009-555-0001",
                IdentityNum: "ADM001122334455"
            );
            admin.AddBusinessRole(_adminRoleId);
            admin.AssignPermissions(GetAdminPermissions());
            admin.SetIdentityId(IdentityType.Admin);
            admin.ChangePassword(PasswordHasher.HashPassword(admin.PhoneNumber));
            return new[] { admin };
        }
        
        private static IEnumerable<Category> SeedCategories()
        {
            Category[] categories = new[] {
                Category.Create(CategoryId.Create(new Guid("B8B7CA84-3F20-4FC1-A316-3A8393F5168D")), "العقيدة"),
                Category.Create(CategoryId.Create(new Guid("F7691610-D73C-4397-84C2-0E634B459C6D")), "الفقه"),
                Category.Create(CategoryId.Create(new Guid("B1F76C08-06C3-4BF9-803C-6D8ECA420673")), "أصول الفقه"),
                Category.Create(CategoryId.Create(new Guid("28C7B687-466D-4448-8D61-8C616AFB80AF")), "القرآن وعلومه"),
                Category.Create(CategoryId.Create(new Guid("1DA09B85-CF90-4DB4-972E-CFD21BFFDE6A")), "الحديث وعلومه"),
                Category.Create(CategoryId.Create(new Guid("F101B36F-F4BD-4F76-859A-D08B372BA1A1")), "السيرة النبوية"),
            };
            return categories;
        }

        private static async Task<IEnumerable<Country>> SeedCountries()
        {
            var filePath = Path.Combine("documents", "countries.json");
            if (!File.Exists(filePath))
                throw new FileNotFoundException("countries.json not found", filePath);
            var json = await File.ReadAllTextAsync(filePath);
            var jsonCountries = JsonSerializer.Deserialize<List<CountryJsonDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new();

            var countryList = new List<Country>();
            int index = 0;
            foreach (var jsonCountry in jsonCountries)
            {
                var countryId = CountryId.Create(jsonCountry.IsoCode);

                var country = Country.CreateInstance(countryId, jsonCountry.DialCode,
                    CountryName.Create(countryId, jsonCountry.NameAr, Culture.ArEg, true)
                );
                country.AddName(CountryName.Create(countryId, jsonCountry.NameEn, Culture.EnUs, false));
                countryList.Add(country);
            }
            return countryList;
        }

        private static IEnumerable<Qualification> SeedQualifications()
        {
            Qualification[] qualification = new[] {
                Qualification.Create("ابتدائي"),
                Qualification.Create("متوسط"),
                Qualification.Create("ثانوي"),
                Qualification.Create("جامعي"),
                Qualification.Create("دبلوم"),
                Qualification.Create("ماجستير"),
                //Qualification.Create("بكالوريوس"),
                Qualification.Create("أخرى")
            };
            return qualification;
        }

        private static IEnumerable<BusinessRolesPermission> GetAdminPermissions()
        {
            // Admin gets all permissions
            return seedPermission
                .Select(p => BusinessRolesPermission.Create(p.Id, _adminRoleId, p.Name));
        }

        private static IEnumerable<BusinessRolesPermission> GetStudentPermissions()
        {
            // Student gets all permissions
            return seedPermission
                .Where(p => p.Tags.Contains("Student") || p.Name.Contains("course.index"))
                .Select(p => BusinessRolesPermission.Create(p.Id, _studentRoleId, p.Name));
        }

        private static IEnumerable<BusinessRolesPermission> GetInstructorPermissions()
        {
            var nameFilters = new[] { "student.index", "student.view" };
            var tagFilters = new[] { "Course", "Instructor" };

            // Instructor gets all permissions
            return seedPermission
                .Where(p => nameFilters.Any(nameF => p.Name.Contains(nameF)) || tagFilters.Any(tagF => p.Tags.Contains(tagF)))
                .Select(p => BusinessRolesPermission.Create(p.Id, _studentRoleId, p.Name));
        }

    }

    public sealed record CountryJsonDto(
            string IsoCode,
            [property: JsonPropertyName("name_ar")] string NameAr,
            [property: JsonPropertyName("name_en")] string NameEn,
            [property: JsonPropertyName("dialCode")] string DialCode
        );
}
