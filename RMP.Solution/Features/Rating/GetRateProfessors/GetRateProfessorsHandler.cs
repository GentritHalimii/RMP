using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Rating.GetRateProfessors;

public sealed record GetRateProfessorsQuery() : IQuery<Result<IEnumerable<GetRateProfessorsResult>>>;

public sealed record GetRateProfessorsResult(
    Guid Id,
    Guid ProfessorId,
    int UserId,
    int Overall,
    string Feedback,
    int? CommunicationSkills,
    int? Responsiveness,
    int? GradingFairness);

internal sealed class GetRateProfessorsQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetRateProfessorsQuery, Result<IEnumerable<GetRateProfessorsResult>>>
{
    public async Task<Result<IEnumerable<GetRateProfessorsResult>>> Handle(GetRateProfessorsQuery query, CancellationToken cancellationToken)
    {
        var rateProfessors = await dbContext.RateProfessors
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var results = rateProfessors.Select(u => u.ToGetRateProfessorsResult());

        return Result.Success(results);
    }
}