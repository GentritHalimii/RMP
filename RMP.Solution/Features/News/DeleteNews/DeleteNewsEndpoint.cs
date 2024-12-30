using Carter;
using MediatR;
using RMP.Host.Extensions;

namespace RMP.Host.Features.News.DeleteNews;

public sealed record DeleteNewsResponse(bool IsSuccess);

public sealed class DeleteNewsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/DeleteNews/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteNewsCommand(id));

                result.Match(
                    onSuccess: () => Results.Ok(result.IsSuccess),
                    onFailure: error => Results.BadRequest(error));
            })
            .WithName("DeleteNews")
            .Produces<DeleteNewsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete News")
            .WithDescription("Delete a news article by its ID.");
    }
}