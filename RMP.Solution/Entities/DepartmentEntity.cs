namespace RMP.Host.Entities;

public class DepartmentEntity
{
    /// <summary>
    /// Unique identifier for the department.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// Name of the department.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Year the department was established.
    /// </summary>
    public required int EstablishedYear { get; set; }

    /// <summary>
    /// Brief description of the department.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Total number of staff members.
    /// </summary>
    public int StaffNumber { get; set; }

    /// <summary>
    /// Total number of students enrolled.
    /// </summary>
    public int StudentsNumber { get; set; }

    /// <summary>
    /// Total number of courses offered.
    /// </summary>
    public int CoursesNumber { get; set; }

    /// <summary>
    /// Path to the Department's profile photo (optional).
    /// </summary>
    
    public ICollection<DepartmentEntity> Departments { get; set; }
}