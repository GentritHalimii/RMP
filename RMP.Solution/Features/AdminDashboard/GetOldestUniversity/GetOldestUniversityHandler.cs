using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.AdminDashboard.GetOldestUniversity;

public sealed record GetOldestUniversityQuery() : IQuery<Result<GetOldestUniversityResult>>;

public sealed record GetOldestUniversityResult(
    Guid Id,
    string Name,
    int EstablishedYear,
    string Description,
    int StaffNumber,
    int StudentsNumber,
    int CoursesNumber,
    string? ProfilePhotoPath);

internal sealed class GetOldestUniversityQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetOldestUniversityQuery, Result<GetOldestUniversityResult>>
{
    public async Task<Result<GetOldestUniversityResult>> Handle(GetOldestUniversityQuery query, CancellationToken cancellationToken)
    {
        var oldestUniversityEntity = await dbContext.Universities
            .AsNoTracking()
            .OrderBy(u => u.EstablishedYear)
            .FirstOrDefaultAsync(cancellationToken);

        var result = oldestUniversityEntity.ToGetOldestUniversityResult();
        return Result.Success(result);
    }
}