using Microsoft.EntityFrameworkCore;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Mapper;

namespace RMP.Host.Features.News.GetAllNewsDescByDate;

public sealed record GetAllNewsDescByDateQuery() : IQuery<Result<IEnumerable<GetAllNewsDescByDateResult>>>;

public sealed record GetAllNewsDescByDateResult(
    Guid Id,
    string Title,
    string Content,
    DateTime PublicationDate,
    string Category,
    string ProfilePhotoPath
);

internal sealed class GetAllNewsDescByDateQueryHandler(ApplicationDbContext dbContext) 
    : IQueryHandler<GetAllNewsDescByDateQuery, Result<IEnumerable<GetAllNewsDescByDateResult>>>
{
    public async Task<Result<IEnumerable<GetAllNewsDescByDateResult>>> Handle(
        GetAllNewsDescByDateQuery query, 
        CancellationToken cancellationToken)
    {
        
        var news = await dbContext
            .News
            .OrderByDescending(n => n.PublicationDate)
            .AsNoTracking() 
            .ToListAsync(cancellationToken);

        
        var result = news.Select(n => n.ToGetAllNewsDescByDateResult());
        
        return Result.Success(result);
    }
}