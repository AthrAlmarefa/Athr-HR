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
    public static class AddCategoryCommandErrors
    {
            public static readonly ApplicationError InvalidCategoryName = new(
                $"{nameof(AddCategoryCommand)}.InvalidCategoryName", "Invalid category name.");

            public static readonly ApplicationError AddDuplicatedCategoryName = new(
                $"{nameof(AddCategoryCommand)}.AddDuplicatedCategoryName", "Duplicated category name.");

    }

}
