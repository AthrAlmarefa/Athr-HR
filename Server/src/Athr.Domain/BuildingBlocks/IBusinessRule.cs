namespace Athr.Domain.BuildingBlocks;

public interface IBusinessRule
{
    Error Error { get; }
    bool IsBroken();
}
