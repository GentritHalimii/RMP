using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Features.RateProfessors;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Rating.GetRateProfessorsByProfessorId;

public sealed record GetRateProfessorsByProfessorIdQuery(Guid Id) : IQuery<Result<IEnumerable<GetRateProfessorsByProfessorIdResult>>>;

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

internal sealed class GetRateProfessorsByProfessorIdQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetRateProfessorsByProfessorIdQuery, Result<IEnumerable<GetRateProfessorsByProfessorIdResult>>>
{
    public async Task<Result<IEnumerable<GetRateProfessorsByProfessorIdResult>>> Handle(GetRateProfessorsByProfessorIdQuery query, CancellationToken cancellationToken)
    {
        var ratings = await dbContext
            .RateProfessors
            .Where(r => r.ProfessorId == query.Id)
            .ToListAsync(cancellationToken);

        if (!ratings.Any())
            return Result.Failure<IEnumerable<GetRateProfessorsByProfessorIdResult>>(RateProfessorsErrors.NotFound(query.Id));
        
        var results = ratings.Select(u => u.ToGetRateProfessorsByProfessorIdResult());

        return Result.Success(results);
    }
}
