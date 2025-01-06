using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;

namespace RMP.Host.Features.AdminDashboard.GetUniversityCount;


public sealed record GetUniversityCountQuery() : IQuery<Result<int>>;

internal sealed class GetUniversityCountQueryHandler(ApplicationDbContext dbContext) : 
    IQueryHandler<GetUniversityCountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetUniversityCountQuery query, CancellationToken cancellationToken)
    {
      
        var universityCount = await dbContext.Universities.CountAsync(cancellationToken);
        
        return Result.Success(universityCount);
    }
}