using Athr.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.UpdateCategory;

public sealed record UpdateCategoryCommand(Guid Id, string Name) : ICommand<Guid>;
