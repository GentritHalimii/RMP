using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Features.RateProfessors;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Rating.GetRateProfessorsByProfessorId;

public sealed record GetRateProfessorsByProfessorIdQuery(Guid Id) : IQuery<Result<GetRateProfessorsByProfessorIdResult>>;

public sealed record GetRateProfessorsByProfessorIdResult(
    Guid Id,
    Guid ProfessorId,
    int UserId,
    int Overall,
    string Feedback,
    int? CommunicationSkills,
    int? Responsiveness,
    int? GradingFairness
);

internal sealed class GetRateProfessorsByProfessorIdQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetRateProfessorsByProfessorIdQuery, Result<GetRateProfessorsByProfessorIdResult>>
{
    public async Task<Result<GetRateProfessorsByProfessorIdResult>> Handle(GetRateProfessorsByProfessorIdQuery query, CancellationToken cancellationToken)
    {
        var professors = await dbContext
            .RateProfessors
            .FirstOrDefaultAsync(n => n.Id == query.Id, cancellationToken);

        if (professors is null)
            return Result.Failure<GetRateProfessorsByProfessorIdResult>(RateProfessorsErrors.NotFound(query.Id));

        return professors.ToGetRateProfessorsByProfessorIdResult();
    }
}