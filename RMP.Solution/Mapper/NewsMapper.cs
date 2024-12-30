using Riok.Mapperly.Abstractions;
using RMP.Host.Entities;
using RMP.Host.Features.News.CreateNews;
using RMP.Host.Features.News.GetNews;
using RMP.Host.Features.News.UpdateNews;
using RMP.Host.Features.News.GetNewsById;
using RMP.Host.Features.News.GetAllNewsDescByDate;
using RMP.Host.Features.News.GetLatestCreatedNews;
using RMP.Host.Features.News.GetThreeLatestCreatedNews;

namespace RMP.Host.Mapper;

[Mapper]
public static partial class NewsMapper
{
    public static partial NewsEntity ToNewsEntity(this CreateNewsCommand command);
    public static partial GetNewsResult ToGetNewsResult(this NewsEntity news);
    public static partial GetNewsResponse ToGetNewsResponse(this GetNewsResult result);
    public static partial GetNewsByIdResult ToGetNewsByIdResult(this NewsEntity news);
    public static partial GetNewsByIdResponse ToGetNewsByIdResponse(this GetNewsByIdResult result);
    public static partial UpdateNewsCommand ToUpdateNewsCommand(this UpdateNewsRequest request);
    public static partial void ToNewsEntity(this UpdateNewsCommand command, NewsEntity entity);
    public static partial GetAllNewsDescByDateResult ToGetAllNewsDescByDateResult(this NewsEntity news);
    public static partial GetAllNewsDescByDateResponse ToGetAllNewsDescByDateResponse(this GetAllNewsDescByDateResult result);
    public static partial GetLatestCreatedNewsResult ToGetLatestCreatedNewsResult(this NewsEntity news);
    public static partial GetThreeLatestCreatedNewsResult ToGetThreeLatestCreatedNewsResult(this NewsEntity news);
    public static partial GetThreeLatestCreatedNewsResponse ToGetThreeLatestCreatedNewsResponse(this GetThreeLatestCreatedNewsResult result);
    public static partial GetLatestCreatedNewsResponse ToGetLatestCreatedNewsResponse(this GetLatestCreatedNewsResult result);
    

}
