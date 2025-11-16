using Ardalis.SmartEnum;

namespace Athr.Domain.BuildingBlocks;

public interface IBusinessRulesProvider<TStatus, TEntity> where TStatus : SmartEnum<TStatus>, IStatusTransition<TStatus>
    where TEntity : class
{
    IEnumerable<StatusTransitionBusinessRule<TStatus>> GetRules(TEntity entity, TStatus to);
}
