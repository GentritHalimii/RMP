using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Course.GetCourses;

public sealed record GetCoursesQuery() : IQuery<Result<IEnumerable<GetCoursesResult>>>;

public sealed record GetCoursesResult(
    Guid Id,
    string Name,
    int CreditHours,
    string Description);

internal sealed class GetCoursesQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetCoursesQuery, Result<IEnumerable<GetCoursesResult>>>
{
    public async Task<Result<IEnumerable<GetCoursesResult>>> Handle(GetCoursesQuery query, CancellationToken cancellationToken)
    {
        var courses = await dbContext.Courses
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var results = courses.Select(u => u.ToGetCoursesResult());

        return Result.Success(results);
    }
}