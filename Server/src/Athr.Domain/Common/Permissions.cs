namespace Athr.Domain.Common;

public static class Permissions
{
    public sealed record Categories
    {
        public const string Create = "category.create";
        public const string View = "category.view";
        public const string Edit = "category.edit";
        public const string Delete = "category.delete";
    }
}
