using Carter;
using MediatR;
using RMP.Host.Extensions;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Rating.GetRateProfessorsByProfessorId;

public sealed record GetRateProfessorsByProfessorIdResponse(
    Guid Id,
    Guid ProfessorId,
    int UserId,
    int Overall,
    string Feedback,
    int? CommunicationSkills,
    int? Responsiveness,
    int? GradingFairness);

public sealed class GetRateProfessorsByProfessorIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/GetRateProfessorsByProfessorId/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetRateProfessorsByProfessorIdQuery(id));

            return result.Match(
                onSuccess: () => Results.Ok(result.Value.ToGetRateProfessorsByProfessorIdResponse()),
                onFailure: error => Results.BadRequest(error));
        })
            .WithName("GetRateProfessorsByProfessorId")
            .Produces<GetRateProfessorsByProfessorIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get RateProfessors by Id")
            .WithDescription("Get RateProfessors by Id");
    }
}