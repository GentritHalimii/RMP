using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;

namespace RMP.Host.Features.Course.DeleteCourse;
public sealed record DeleteCourseCommand(Guid Id) : ICommand<Result<DeleteCourseResult>>;
public sealed record DeleteCourseResult(bool IsSuccess);

internal sealed class DeleteCourseCommandHandler(ApplicationDbContext dbContext) : ICommandHandler<DeleteCourseCommand, Result<DeleteCourseResult>>
{
    public async Task<Result<DeleteCourseResult>> Handle(DeleteCourseCommand command, CancellationToken cancellationToken)
    {
        var course = await dbContext
            .Courses
            .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken);

        if (course is null)
            return Result.Failure<DeleteCourseResult>(CourseErrors.NotFound(command.Id));

        dbContext.Courses.Remove(course);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteCourseResult(true);
    }
}