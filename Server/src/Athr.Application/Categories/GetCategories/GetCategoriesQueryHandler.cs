using Athr.Application.Abstractions.Messaging;
using Athr.Application.Common;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.GetCategories;

public sealed class GetCategoriesQueryHandler(ICategoryRepository _categoryRepository) : IQueryHandler<GetCategoriesQuery, PaginatedList<CategoryResponse>>
{
    public async Task<PaginatedList<CategoryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories =  _categoryRepository.All().Skip((request.CurrentPage - 1) * request.PerPage)
            .Take(request.PageSize).Select(c => new CategoryResponse(c.Id, c.Name)).ToArray();
        var paginatedList = new PaginatedList<CategoryResponse>()
        {
            Data = categories,
            CurrentPage = request.CurrentPage,
            PerPage = request.PerPage,
            Total = await _categoryRepository.All().CountAsync(cancellationToken),
        };
        return paginatedList;
    }
}
