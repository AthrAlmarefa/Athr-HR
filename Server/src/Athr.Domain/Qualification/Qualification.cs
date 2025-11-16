using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Qualification
{
    public sealed class Qualification : Entity<QualificationId>
    {
        private Qualification(string name)
        {
            Name = name;
        }

        public QualificationId Id { get; }
        private Qualification()
        {
        }

        public string Name { get; private set; }

        public static Qualification Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new BusinessRuleException([new Error($"{nameof(Qualification)}.{nameof(Name)}.IsNullOrEmpty",
                    "Qualification name cannot be empty.")]);

            return new(name);
        }
    }
}
