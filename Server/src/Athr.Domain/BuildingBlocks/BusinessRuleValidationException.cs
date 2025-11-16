namespace Athr.Domain.BuildingBlocks;

public class BusinessRuleValidationException : Exception
{
    internal BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Error.Message)
    {
        BrokenRule = brokenRule;
        Details = brokenRule.Error.Message;
    }

    public IBusinessRule BrokenRule { get; }
    public string Details { get; }

    public override string ToString()
    {
        return $"{BrokenRule.GetType().FullName}: {BrokenRule.Error.Message}";
    }
}
