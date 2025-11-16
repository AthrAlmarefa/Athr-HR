using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Categories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.UpdateCategory;

public sealed class UpdateCategoryCommandHandler(IUnitOfWork _unitOfWork, ICategoryRepository _categoryRepository) : ICommandHandler<UpdateCategoryCommand, Guid>
{
    public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);
        if (category == null || category.IsDeleted)
            throw new ApplicationFlowException([UpdateCategoryCommandErrors.CategoryNotFound]);

        if (category.Name != request.Name)
        {
            var duplicateExists = await _categoryRepository
                .All().AnyAsync(c => c.Name == request.Name, cancellationToken);

            if (duplicateExists)
                throw new ApplicationFlowException([UpdateCategoryCommandErrors.UpdateDuplicatedCategoryName]);
        }

        category.UpdateName(request.Name);
        _categoryRepository.Update(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return category.Id.Value;
    }
}
