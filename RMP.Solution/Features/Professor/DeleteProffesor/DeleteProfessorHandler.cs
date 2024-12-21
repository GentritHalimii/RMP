using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Features.Proffesor;

namespace RMP.Host.Features.Professor.DeleteProfessor;
public sealed record DeleteProfessorCommand(Guid Id) : ICommand<Result<DeleteProfessorResult>>;
public sealed record DeleteProfessorResult(bool IsSuccess);

internal sealed class DeleteProfessorCommandHandler(ApplicationDbContext dbContext) : ICommandHandler<DeleteProfessorCommand, Result<DeleteProfessorResult>>
{
    public async Task<Result<DeleteProfessorResult>> Handle(DeleteProfessorCommand command, CancellationToken cancellationToken)
    {
        var professor = await dbContext
            .Professors
            .FirstOrDefaultAsync(p => p.Id == command.Id, cancellationToken);

        if (professor is null)
            return Result.Failure<DeleteProfessorResult>(ProfessorErrors.NotFound(command.Id));

        dbContext.Professors.Remove(professor);

        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteProfessorResult(true);
    }
}