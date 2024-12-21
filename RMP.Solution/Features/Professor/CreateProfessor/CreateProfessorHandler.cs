using FluentValidation;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Professor.CreateProfessor;

public sealed record CreateProfessorCommand(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Education,
    string Role,
    string ProfilePhotoPath) : ICommand<Result<CreateProfessorResult>>;

public sealed record CreateProfessorResult(Guid Id);

public sealed class CreateProfessorCommandValidator : AbstractValidator<CreateProfessorCommand>
{
    public CreateProfessorCommandValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required!");
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required!");

    }
}

internal sealed class CreateProfessorCommandHandler(ApplicationDbContext dbContext) : ICommandHandler<CreateProfessorCommand, Result<CreateProfessorResult>>
{
    public async Task<Result<CreateProfessorResult>> Handle(CreateProfessorCommand command, CancellationToken cancellationToken)
    {
        var professor = command.ToProfessorEntity();

        dbContext.Professors.Add(professor);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProfessorResult(professor.Id);
    }
}