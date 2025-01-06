using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.AdminDashboard.GetHighestRatedUniversity;

public sealed record GetHighestRatedUniversityQuery() : IQuery<Result<GetHighestRatedUniversityResult>>;

public sealed record GetHighestRatedUniversityResult(
    Guid UniversityId);

internal sealed class GetHighestRatedUniversityQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetHighestRatedUniversityQuery, Result<GetHighestRatedUniversityResult>>
{
    public async Task<Result<GetHighestRatedUniversityResult>> Handle(GetHighestRatedUniversityQuery query, CancellationToken cancellationToken)
    {
        var highestRatedUniversityEntity = await dbContext.RateUniversities
            .Include(ru => ru.University)
            .AsNoTracking()
            .OrderByDescending(ru => ru.Overall)
            .FirstOrDefaultAsync(cancellationToken);

        var result = highestRatedUniversityEntity.ToGetHighestRatedUniversityResult();
        return Result.Success(result);
    }
}