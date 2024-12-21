using RMP.Host.Abstarctions.Errors;

namespace RMP.Host.Features.Proffesor;

public static class ProfessorErrors
{
    public static Error NotFound(Guid id) =>
        new("Proffesors.NotFound", $"The proffesor with Id '{id}' was not found");
}