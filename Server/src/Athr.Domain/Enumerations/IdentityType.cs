using Ardalis.SmartEnum;

namespace Athr.Domain.Enumerations
{
    public sealed class IdentityType : SmartEnum<IdentityType, int>
    {
        public static readonly IdentityType Admin = new("AD", 1);

        private IdentityType(string name, int value)
            : base(name, value) { }
    }
}
