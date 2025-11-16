using Athr.Domain.BuildingBlocks;

namespace Athr.Domain.Common
{
    #region GenderErrors
    internal static class GenderErrors
    {
        public static readonly Error InvalidGenderType = new("Gender.InvalidGenderType",
            "Gender Type Must Be In Male Or Female");
    }
    #endregion

    public sealed record Gender
    {
        public static readonly Gender Male = new(Constants.GENDER_MALE);
        internal static readonly Gender Female = new(Constants.GENDER_FEMALE);

        public static readonly IReadOnlyCollection<Gender> All = new[] { Female, Male };

        private Gender() { }
        private Gender(string gender)
        {
            Code = gender ?? throw new BusinessRuleException([GenderErrors.InvalidGenderType]);
        }

        public string Code { get; init; }

        public static Gender FromCode(string gender)
        {
            return All.FirstOrDefault(c => gender.Equals(c.Code, StringComparison.OrdinalIgnoreCase)) ??
                   throw new BusinessRuleException([GenderErrors.InvalidGenderType]);
        }
    }
}


