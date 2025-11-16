using Athr.Application.Categories.AddCategory;
using Athr.Application.Categories.DeleteCategory;
using Athr.Application.Categories.UpdateCategory;
using Athr.Application.Exceptions;
using Athr.Application.Users.LogInUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories
{
    public static class UpdateCategoryCommandErrors
    {
            public static readonly ApplicationError UpdateDuplicatedCategoryName = new(
                    $"{nameof(UpdateCategoryCommand)}.UpdateDuplicatedCategoryName", "Duplicated category name or not found category.");

        public static readonly ApplicationError CategoryNotFound = new(
                             $"{nameof(UpdateCategoryCommand)}.CategoryNotFound", "Category not found.");
    }

}
