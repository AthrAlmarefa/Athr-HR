namespace Athr.Domain.BuildingBlocks;

public interface IStatusTransitionStrategyFactory<in T, TStatus>
{
    IStatusTransitionStrategy<T, TStatus> GetStrategy(TStatus status);
}
