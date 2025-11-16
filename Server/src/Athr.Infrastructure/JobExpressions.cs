namespace Athr.Infrastructure;

public sealed class JobExpressions
{
    public string SessionOccurrenceExpression { get; init; }
    public string EnrollmentStatusTransitionExpression { get; init; }
    public string ExamStatusTransitionExpression { get; init; }
    public string HomeworkStatusTransitionExpression { get; init; }
}
