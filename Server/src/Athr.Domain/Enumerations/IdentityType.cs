using Ardalis.SmartEnum;

namespace Athr.Domain.Enumerations
{
    public sealed class IdentityType : SmartEnum<IdentityType, int>
    {
        public static readonly IdentityType Student = new("ST", 1);
        public static readonly IdentityType Admin = new("AD", 2);
        public static readonly IdentityType Instructor = new("INS", 3);
        public static readonly IdentityType Parent = new("PR", 4);

        private IdentityType(string name, int value)
            : base(name, value) { }
    }
}
