using Asp.Versioning;
using FluentValidation;
using FluentValidation.Results;
using Athr.Api.Controllers;
using Athr.Application.Categories;
using Athr.Application.Categories.AddCategory;
using Athr.Application.Categories.DeleteCategory;
using Athr.Application.Categories.GetCategories;
using Athr.Application.Categories.GetCategoryById;
using Athr.Application.Categories.UpdateCategory;
using Athr.Application.Common;
using Athr.Domain.Categories;
using Athr.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace Athr.Api.Controllers.Categories;

[ApiController]
[ApiVersion(ApiVersions.V1)]
[Route("api/v{version:apiVersion}/category")]
public class CategoryController : Controller
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<PaginatedList<CategoryResponse>> GetCategories([FromQuery] GetCategoriesRequest request)
    {
        GetCategoriesQuery query = request;
        return await _sender.Send(query);
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    public async Task<Guid> AddCategory(AddCategoryRequest request)
    {
         AddCategoryCommand command = request;
        return await _sender.Send(command);
    }

    [HttpPut]
    //[Authorize(Roles = "Admin")]
    public async Task<Guid> UpdateCategory(UpdateCategoryRequest request)
    {
        UpdateCategoryCommand command = request;
        return await _sender.Send(command);
    }

    [HttpPatch("{categoryId:guid}")]
    //[Authorize(Roles = "Admin")]
    public async Task DeleteCategory(Guid categoryId)
    {
        var command = new DeleteCategoryCommand(categoryId);
        await _sender.Send(command);
    }

    [HttpGet("{id:guid}")]
    public async Task<CategoryResponse> GetCategory(Guid id)
    {
        var query = new GetCategoryByIdQuery(id);
        return await _sender.Send(query);
    }
    
}
