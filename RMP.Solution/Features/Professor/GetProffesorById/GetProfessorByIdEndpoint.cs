using Carter;
using MediatR;
using RMP.Host.Extensions;
using RMP.Host.Mapper;

namespace RMP.Host.Features.Professor.GetProffesorById;

public sealed record GetProfessorByIdResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Education,
    string Role,
    string ProfilePhotoPath);

public sealed class GetProfessorByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/GetProfessorById/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetProfessorByIdQuery(id));

                return result.Match(
                    onSuccess: () => Results.Ok(result.Value.ToGetProfessorByIdResponse()),
                    onFailure: error => Results.BadRequest(error));
            })
            .WithName("GetProfessorById")
            .Produces<GetProfessorByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Professor by Id")
            .WithDescription("Get Professor by Id");
    }
}

