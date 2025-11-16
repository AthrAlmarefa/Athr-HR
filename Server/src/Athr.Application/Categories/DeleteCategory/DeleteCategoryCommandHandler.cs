using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.DeleteCategory;

public sealed class DeleteCategoryCommandHandler(IUnitOfWork _unitOfWork, ICategoryRepository _categoryRepository) : ICommandHandler<DeleteCategoryCommand>
{
    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new ApplicationFlowException([DeleteCategoryCommandErrors.CategoryNotFound]);
        
        category.MarkAsDeleted();
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
