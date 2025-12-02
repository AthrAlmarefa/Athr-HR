using Ardalis.SmartEnum;
using Athr.Domain.Users;

namespace Athr.Domain.BuildingBlocks;

public abstract class StatusTransitionBusinessRule<TStatus> : IBusinessRule
    where TStatus : SmartEnum<TStatus>, IStatusTransition<TStatus>
{
    protected StatusTransitionBusinessRule(TStatus from, TStatus to, UserEntity user)
    {
        From = from;
        To = to;
        User = user;
    }

    public TStatus From { get; }
    public TStatus To { get; }

    private UserEntity User { get; }

    public bool IsBroken()
    {
        return IsAllowedStatusTransition() && IsBrokenCore();
    }

    public abstract Error Error { get; protected internal set; }

    protected abstract bool IsBrokenCore();

    private bool IsAllowedStatusTransition()
    {
        return From == To || From.CanTransitionTo(To);
    }

#pragma warning disable S3400
    protected bool CheckCurrentUserBelongsToTeam()
#pragma warning restore S3400
    {
#pragma warning disable S125
        return true; // User.Teams.Any(team => To.TeamsNames.Contains(userTeam.Name));
#pragma warning restore S125
    }
}
