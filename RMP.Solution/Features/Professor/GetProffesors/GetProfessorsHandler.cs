using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Professor.GetProfessors;

public sealed record GetProfessorsQuery() : IQuery<Result<IEnumerable<GetProfessorsResult>>>;

public sealed record GetProfessorsResult(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Education,
    string Role,
    string ProfilePhotoPath);

internal sealed class GetProfessorsQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetProfessorsQuery, Result<IEnumerable<GetProfessorsResult>>>
{
    public async Task<Result<IEnumerable<GetProfessorsResult>>> Handle(GetProfessorsQuery query, CancellationToken cancellationToken)
    {
        var professors = await dbContext.Professors
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        var results = professors.Select(u => u.ToGetProfessorsResult());

        return Result.Success(results);
    }
}
