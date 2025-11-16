using Athr.Application.Categories.GetCategories;

namespace Athr.Api.Controllers.Categories;

public sealed record GetCategoriesRequest(int currentPage, int perPage, int pageSize = 10)
{
    public static implicit operator GetCategoriesQuery(GetCategoriesRequest request)
         => new(request.currentPage, request.perPage, request.pageSize);

};
