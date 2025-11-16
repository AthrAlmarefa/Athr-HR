namespace Athr.Domain.Qualification;

public interface IQualificationRepository
{
    Task<Qualification?> GetByIdAsync(
        QualificationId qualificationId,
        CancellationToken cancellationToken = default);
    IQueryable<Qualification> All();

    Task AddAsync(Qualification user);

}
