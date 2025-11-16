using Athr.Application.Categories.UpdateCategory;

namespace Athr.Api.Controllers.Categories
{
    public sealed record UpdateCategoryRequest(Guid id, string name)
    {
        public static implicit operator UpdateCategoryCommand(UpdateCategoryRequest request)
        {
            return new UpdateCategoryCommand(request.id, request.name);
        }
    }
}
