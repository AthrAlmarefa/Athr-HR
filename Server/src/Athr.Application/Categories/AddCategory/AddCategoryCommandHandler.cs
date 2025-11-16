using Athr.Application.Abstractions.Messaging;
using Athr.Application.Exceptions;
using Athr.Application.Users.LogInUser;
using Athr.Domain.BuildingBlocks;
using Athr.Domain.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Athr.Application.Categories.AddCategory;

internal sealed class AddCategoryCommandHandler(IUnitOfWork _unitOfWork, ICategoryRepository _categoryRepository) : ICommandHandler<AddCategoryCommand, Guid>
{
    public async Task<Guid> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
        if (_categoryRepository.All().Any(a => a.Name == request.Name))
            throw new ApplicationFlowException([AddCategoryCommandErrors.AddDuplicatedCategoryName]);

        var category = Category.Create(request.Name) ;
        await _categoryRepository.AddAsync(category);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return category.Id.Value;   
    }
}
