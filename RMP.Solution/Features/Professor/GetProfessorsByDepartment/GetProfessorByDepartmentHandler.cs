using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Professor.GetProfessorsByDepartment;

public sealed record GetProfessorsByDepartmentQuery(Guid DepartmentId) : IQuery<Result<IEnumerable<GetProfessorsByDepartmentResult>>>;

public sealed record GetProfessorsByDepartmentResult(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Education,
    string Role,
    string ProfilePhotoPath);

internal sealed class GetProfessorsByDepartmentQueryHandler(ApplicationDbContext dbContext) : IQueryHandler<GetProfessorsByDepartmentQuery, Result<IEnumerable<GetProfessorsByDepartmentResult>>>
{
    public async Task<Result<IEnumerable<GetProfessorsByDepartmentResult>>> Handle(GetProfessorsByDepartmentQuery query, CancellationToken cancellationToken)
    {
        var professors = await dbContext.DepartmentProfessors
            .Where(dp => dp.DepartmentId == query.DepartmentId)
            .Select(dp => dp.Professor)
            .ToListAsync(cancellationToken: cancellationToken);

        var results = professors.Select(u => u.ToGetProfessorsByDepartmentResult());

        return Result.Success(results);
    }
}