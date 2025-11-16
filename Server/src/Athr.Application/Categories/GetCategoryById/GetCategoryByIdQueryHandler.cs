using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.GetCategoryById;

public sealed class GetCategoryByIdQueryHandler(ICategoryRepository _categoryRepository) : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
{
    public async Task<CategoryResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken) ?? throw new ApplicationFlowException([CategoryQueryErrors.CategoryNotFound]);
        return new CategoryResponse(category.Id.Value, category.Name);
    }
}
