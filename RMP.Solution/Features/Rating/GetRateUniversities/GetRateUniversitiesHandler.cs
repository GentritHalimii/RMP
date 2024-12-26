using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Rating.GetRateUniversities;

public sealed record GetRateUniversitiesQuery() : IQuery<Result<IEnumerable<GetRateUniversitiesResult>>>;

public sealed record GetRateUniversitiesResult(
    Guid Id,
    Guid UniversityId,
    int UserId,
    int Overall,
    string Feedback);

internal sealed class GetRateUniversitiesQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetRateUniversitiesQuery, Result<IEnumerable<GetRateUniversitiesResult>>>
{
    public async Task<Result<IEnumerable<GetRateUniversitiesResult>>> Handle(GetRateUniversitiesQuery query, CancellationToken cancellationToken)
    {
        var rateUniversities = await dbContext.RateUniversities
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var results = rateUniversities.Select(u => u.ToGetRateUniversitiesResult());

        return Result.Success(results);
    }
}