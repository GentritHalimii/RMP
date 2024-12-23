using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RMP.Host.Extensions;

namespace RMP.Host.Features.Department.CreateDepartment;

public sealed record CreateDepartmentResponse(Guid Id);

public sealed class CreateDepartmentEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/CreateDepartment", [IgnoreAntiforgeryToken] async (
                string name,
                int establishedYear,
                string description,
                int staffNumber,
                int studentsNumber,
                int coursesNumber,
                ISender sender) =>
            {
                Guid id = Guid.NewGuid();
                
                var command = new CreateDepartmentCommand(
                    id,
                    name,
                    establishedYear,
                    description,
                    staffNumber,
                    studentsNumber,
                    coursesNumber);

                var result = await sender.Send(command);
                return result.Match(
                    onSuccess: () => Results.Created($"api/CreateDepartment/{result.Value.Id}", result.Value),
                    onFailure: error => Results.BadRequest(error));
            })
            .WithName("CreateDepartment")
            .DisableAntiforgery()
            .Produces<CreateDepartmentResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Department")
            .WithDescription("Endpoint for creating a department.");
    }
}