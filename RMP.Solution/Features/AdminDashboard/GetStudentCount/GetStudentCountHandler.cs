using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Features.User.Common;

namespace RMP.Host.Features.AdminDashboard.GetStudentCount;


public sealed record GetStudentCountQuery() : IQuery<Result<int>>;

internal sealed class GetStudentCountQueryHandler(ApplicationDbContext dbContext) : 
    IQueryHandler<GetStudentCountQuery, Result<int>>
{
    public async Task<Result<int>> Handle(GetStudentCountQuery query, CancellationToken cancellationToken)
    {
      
        var studentCount = await dbContext.UserRoles
            .CountAsync(ur => ur.RoleId == (int)UserRoleType.Student);
        
        return Result.Success(studentCount);
    }
}