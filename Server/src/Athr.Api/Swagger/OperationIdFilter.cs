using System.Globalization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Athr.Api.Swagger;

public class OperationIdFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
#pragma warning disable S125 // Sections of code should not be commented out
        string actionName = context.MethodInfo.Name;
        //string controllerName = context.ApiDescription.ActionDescriptor.RouteValues["controller"];
        operation.OperationId = actionName;
    }
}
