using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Categories;

public sealed class Category : Entity<CategoryId>, IRecoverable
{
    private Category(CategoryId categoryId, string name) : base(categoryId)
    {
        Name = name;
    }

    private Category() { }
    public string Name { get; private set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public void Recover()
    {
        IsDeleted = false;
    }
    public void MarkAsDeleted()
    {
        IsDeleted = true;
        DeletedAt = DateTimeOffset.UtcNow;
    }
    public void UpdateName(string name)
    {
        Name = name;
    }
    
    public static Category Create(string name)
    {
        return new Category(CategoryId.CreateUnique(), name);
    }

    public static Category Create(CategoryId id, string name)
    {
        return new Category(id, name);
    }
}
