using FluentValidation;
using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Course.UpdateCourse;
public sealed record UpdateCourseCommand(
    Guid Id,
    string Name,
    int CreditHours,
    string Description) : ICommand<Result<UpdateCourseResult>>;
public sealed record UpdateCourseResult(bool IsSuccess);

public sealed class UpdateCourseCommandValidator :
    AbstractValidator<UpdateCourseCommand>
{
    public UpdateCourseCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required!");
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required!");
        RuleFor(x => x.CreditHours)
            .GreaterThan(0)
            .WithMessage("Credit hours must be greater than zero.");
    }
}

internal sealed class UpdateCourseCommandHandler(ApplicationDbContext dbContext) : ICommandHandler<UpdateCourseCommand, Result<UpdateCourseResult>>
{
    public async Task<Result<UpdateCourseResult>> Handle(UpdateCourseCommand command, CancellationToken cancellationToken)
    {
        var course = await dbContext
            .Courses
            .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken);

        if (course is null)
            return Result.Failure<UpdateCourseResult>(CourseErrors.NotFound(command.Id));

        command.ToCourseEntity(course);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new UpdateCourseResult(true);
    }
}