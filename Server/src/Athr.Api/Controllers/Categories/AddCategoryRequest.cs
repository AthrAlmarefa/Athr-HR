using Athr.Application.Categories.AddCategory;

namespace Athr.Api.Controllers.Categories;

public sealed record AddCategoryRequest(string name)
{
    public static implicit operator AddCategoryCommand(AddCategoryRequest request)
    {
        return new AddCategoryCommand(request.name);
    }
}
