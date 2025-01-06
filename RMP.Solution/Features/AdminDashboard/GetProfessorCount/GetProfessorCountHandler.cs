using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;

namespace RMP.Host.Features.AdminDashboard.GetProfessorCount;


public sealed record GetProfessorCountQuery() : IQuery<Result<int>>;

internal sealed class GetProfessorCountQueryHandler(ApplicationDbContext dbContext) : 
    IQueryHandler<GetProfessorCountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetProfessorCountQuery query, CancellationToken cancellationToken)
    {
      
        var professorCount = await dbContext.Professors.CountAsync(cancellationToken);
        
        return Result.Success(professorCount);
    }
}