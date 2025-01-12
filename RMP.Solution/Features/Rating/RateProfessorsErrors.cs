using RMP.Host.Abstarctions.Errors;

namespace RMP.Host.Features.RateProfessors;

public static class RateProfessorsErrors
{
    public static Error NotFound(Guid id) =>
        new("RateProfessors.NotFound", $"The rateProfessors with Id '{id}' was not found");

    public static Error NotFoundRateProfessors() =>
        new("RateProfessors.NotFoundRateProfessors", $"The rateProfessors  wasn't not found");


}