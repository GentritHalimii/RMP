using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Features.RateProfessors;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Rating.GetRateProfessorsByStudentId;

public sealed record GetRateProfessorsByStudentIdQuery(Guid Id) : IQuery<Result<GetRateProfessorsByStudentIdResult>>;

public sealed record GetRateProfessorsByStudentIdResult(
    Guid Id,
    Guid ProfessorId,
    int UserId,
    int Overall,
    string Feedback,
    int? CommunicationSkills,
    int? Responsiveness,
    int? GradingFairness
);

internal sealed class GetRateProfessorsByStudentIdQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetRateProfessorsByStudentIdQuery, Result<GetRateProfessorsByStudentIdResult>>
{
    public async Task<Result<GetRateProfessorsByStudentIdResult>> Handle(GetRateProfessorsByStudentIdQuery query, CancellationToken cancellationToken)
    {
        var news = await dbContext
            .RateProfessors
            .FirstOrDefaultAsync(n => n.Id == query.Id, cancellationToken);

        if (news is null)
            return Result.Failure<GetRateProfessorsByStudentIdResult>(RateProfessorsErrors.NotFound(query.Id));

        return news.ToGetRateProfessorsByStudentIdResult();
    }
}