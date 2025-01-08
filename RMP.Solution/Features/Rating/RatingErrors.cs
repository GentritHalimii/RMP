using RMP.Host.Abstarctions.Errors;

namespace RMP.Host.Features.Rating;

public static class RatingErrors
{
    public static Error IsToxic(string message) =>
        new("Toxic", message);
}