using Athr.Application.Abstractions.Messaging;

namespace Athr.Application.Categories.AddCategory;
public sealed record AddCategoryCommand(string Name) : ICommand<Guid>;
