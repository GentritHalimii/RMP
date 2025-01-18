
using Riok.Mapperly.Abstractions;
using RMP.Host.Entities;
using RMP.Host.Features.Professor.CreateProfessor;
using RMP.Host.Features.Professor.UpdateProfessor;
using RMP.Host.Features.Professor.GetProfessors;
using RMP.Host.Features.Professor.GetProfessorsByDepartment;
using RMP.Host.Features.Professor.GetProffesorById;
using RMP.Host.Features.Professor.GetProffesors;

namespace RMP.Host.Mapper;

[Mapper]
public static partial class ProfessorMapper
{
    public static partial ProfessorEntity ToProfessorEntity(this CreateProfessorCommand command);
    public static partial void ToProfessorEntity(this UpdateProfessorCommand command, ProfessorEntity entity);
    public static partial UpdateProfessorCommand ToUpdateProfessorCommand(this UpdateProfessorRequest request);
    public static partial GetProfessorByIdResult ToGetProfessorByIdResult(this ProfessorEntity professor);
    public static partial GetProfessorByIdResponse ToGetProfessorByIdResponse(this GetProfessorByIdResult result);
    public static partial GetProfessorsResult ToGetProfessorsResult(this ProfessorEntity professor);
    public static partial GetProfessorsResponse ToGetProfessorsResponse(this GetProfessorsResult result);
    public static partial GetProfessorsByDepartmentResult ToGetProfessorsByDepartmentResult(this ProfessorEntity professor);
    public static partial GetProfessorsByDepartmentResponse ToGetProfessorsByDepartmentResponse(this GetProfessorsByDepartmentResult professor);
}