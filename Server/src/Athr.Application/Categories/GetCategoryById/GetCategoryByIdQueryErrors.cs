using Athr.Application.Exceptions;
using Athr.Application.Users.LogInUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.GetCategoryById
{
    public static class CategoryQueryErrors
    {
            public static readonly ApplicationError CategoryNotFound = new(
                $"{nameof(GetCategoryByIdQuery)}.CategoryNotFound", "Category not found.");

    }
    
}
