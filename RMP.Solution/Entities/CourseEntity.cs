namespace RMP.Host.Entities
{
    public class CourseEntity : BaseEntity
    {

        /// <summary>
        /// Foreign key from Department
        /// </summary>
        public Guid DepartmentID { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public string Description {  get; set; }
        public DepartmentEntity Department { get; set; }

        public ICollection<ProfessorCourseEntity> ProfessorCourses { get; set; }
    }
}
