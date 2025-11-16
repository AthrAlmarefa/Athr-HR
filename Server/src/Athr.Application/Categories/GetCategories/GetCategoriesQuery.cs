using Athr.Application.Abstractions.Messaging;
using Athr.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Athr.Application.Categories.GetCategories;

public sealed record GetCategoriesQuery(int CurrentPage, int PerPage, int PageSize) : IQuery<PaginatedList<CategoryResponse>>;
