using Athr.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.DeleteCategory;

public sealed record DeleteCategoryCommand(Guid Id) : ICommand;

