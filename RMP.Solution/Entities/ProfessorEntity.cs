namespace RMP.Host.Entities;

public class ProfessorEntity : BaseEntity
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string UserName { get; set; }
    
    public string Email { get; set; }
    
    public string Education { get; set; }
    
    public string Role { get; set; }
    
    public string? ProfilePhotoPath { get; set; }
}