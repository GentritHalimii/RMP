using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Features.Proffesor;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Professor.GetProffesorById;
public sealed record GetProfessorByIdQuery(Guid Id) : IQuery<Result<GetProfessorByIdResult>>;
public sealed record GetProfessorByIdResult(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Education,
    string Role,
    string ProfilePhotoPath);

internal sealed class GetProfessorByIdQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetProfessorByIdQuery, Result<GetProfessorByIdResult>>
{
    public async Task<Result<GetProfessorByIdResult>> Handle(GetProfessorByIdQuery query, CancellationToken cancellationToken)
    {
        var proffesor = await dbContext
            .Professors
            .FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken);

        if (proffesor is null)
            return Result.Failure<GetProfessorByIdResult>(ProfessorErrors.NotFound(query.Id));

        return proffesor.ToGetProfessorByIdResult();
    }
}


