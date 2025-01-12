using Carter;
using MediatR;
using RMP.Host.Extensions;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Rating.GetRateProfessorsByStudentId;

public sealed record GetRateProfessorsByStudentIdResponse(
    Guid Id,
    Guid ProfessorId,
    int UserId,
    int Overall,
    string Feedback,
    int? CommunicationSkills,
    int? Responsiveness,
    int? GradingFairness);

public sealed class GetRateProfessorsByStudentIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/GetRateProfessorsByStudentId/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetRateProfessorsByStudentIdQuery(id));

            return result.Match(
                onSuccess: () => Results.Ok(result.Value.ToGetRateProfessorsByStudentIdResponse()),
                onFailure: error => Results.BadRequest(error));
        })
            .WithName("GetRateProfessorsByStudentId")
            .Produces<GetRateProfessorsByStudentIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get RateProfessors by student Id")
            .WithDescription("Get RateProfessors by student Id");
    }
}