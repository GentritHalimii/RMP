namespace RMP.Host.Entities
{
    public class ProfessorCourseEntity
    {
        //Foreign Key
        public Guid ProfessorId { get; set; }

        //Foreign Key
        public Guid CourseId { get; set; }
        public virtual ProfessorEntity Professor { get; set; }
        public virtual CourseEntity Course { get; set; }
    }
}
