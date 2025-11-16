namespace Athr.Domain.BuildingBlocks;

public class StatusTransitionStrategyException<TStatus> : Exception
{
    public StatusTransitionStrategyException(TStatus status) : base($"No strategy found for status {nameof(status)}")
    {

    }
}
