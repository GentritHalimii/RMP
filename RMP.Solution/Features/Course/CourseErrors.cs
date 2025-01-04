using RMP.Host.Abstarctions.Errors;

namespace RMP.Host.Features.Course;

public static class CourseErrors
{
    public static Error NotFound(Guid id) =>
        new("Courses.NotFound", $"The course with Id '{id}' was not found");
}