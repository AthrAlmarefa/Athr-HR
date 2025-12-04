namespace Athr.Domain.BuildingBlocks
{
    public interface IPoNumberGenerator
    {
        string GeneratePoNumber(DateTime createdDate);
    }
}
