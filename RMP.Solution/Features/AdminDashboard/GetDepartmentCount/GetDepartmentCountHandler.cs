using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;

namespace RMP.Host.Features.AdminDashboard.GetDepartmentCount;


public sealed record GetDepartmentCountQuery() : IQuery<Result<int>>;

internal sealed class GetDepartmentCountQueryHandler(ApplicationDbContext dbContext) : 
    IQueryHandler<GetDepartmentCountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetDepartmentCountQuery query, CancellationToken cancellationToken)
    {
      
        var departmentCount = await dbContext.Departments.CountAsync(cancellationToken);
        
        return Result.Success(departmentCount);
    }
}