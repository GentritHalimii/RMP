using Carter;
using MediatR;
using RMP.Host.Extensions;
using RMP.Host.Mapper;

namespace RMP.Host.Features.AdminDashboard.GetHighestRatedUniversity;

public sealed record GetHighestRatedUniversityResponse(
    Guid UniversityId);

public sealed class GetHighestRatedUniversityEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/AdminDashboard/HighestRatedUniversity", async (ISender sender) =>
            {
                var result = await sender.Send(new GetHighestRatedUniversityQuery());

                return result.Match(
                    onSuccess: () =>
                    {
                        var response = result.Value.ToGetHighestRatedUniversityResponse();
                        return Results.Ok(response);
                    },
                    onFailure: error => Results.BadRequest(error));
            })
            .WithName("GetHighestRatedUniversity")
            .Produces<GetHighestRatedUniversityResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Highest Rated University")
            .WithDescription("Retrieve the highest-rated university along with its overall rating.");
    }
}