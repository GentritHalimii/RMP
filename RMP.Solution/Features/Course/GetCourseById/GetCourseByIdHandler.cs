using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Course.GetCourseById;
public sealed record GetCourseByIdQuery(Guid Id) : IQuery<Result<GetCourseByIdResult>>;

public sealed record GetCourseByIdResult(
    Guid Id,
    string Name,
    int CreditHours,
    string Description)
;

internal sealed class GetCourseByIdQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetCourseByIdQuery, Result<GetCourseByIdResult>>
{
    public async Task<Result<GetCourseByIdResult>> Handle(GetCourseByIdQuery query, CancellationToken cancellationToken)
    {
        var course = await dbContext
            .Courses
            .FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken);

        if (course is null)
            return Result.Failure<GetCourseByIdResult>(CourseErrors.NotFound(query.Id));

        return course.ToGetCourseByIdResult();
    }
}