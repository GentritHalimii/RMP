using Riok.Mapperly.Abstractions;
using RMP.Host.Entities;
using RMP.Host.Features.News.GetNewsById;
using RMP.Host.Features.Rating.GetRateProfessorsById;
using RMP.Host.Features.Rating.GetRateProfessors;
using RMP.Host.Features.Rating.GetRateProfessorsByProfessorId;
using RMP.Host.Features.Rating.GetRateUniversities;
using RMP.Host.Features.Rating.GetRateProfessorsByStudentId;

namespace RMP.Host.Mapper;

[Mapper]
public static partial class RatingMapper
{
    public static partial GetRateProfessorsResult ToGetRateProfessorsResult(this RateProfessorEntity rateProfessor);
    public static partial GetRateProfessorsResponse ToGetRateProfessorsResponse(this GetRateProfessorsResult result);
    public static partial GetRateUniversitiesResult ToGetRateUniversitiesResult(this RateUniversityEntity rateUniversity);
    public static partial GetRateUniversitiesResponse ToGetRateUniversitiesResponse(this GetRateUniversitiesResult result);
    public static partial GetRateProfessorsByIdResult ToGetRateProfessorsByIdResult(this RateProfessorEntity rateProfessor);
    public static partial GetRateProfessorsByIdResponse ToGetRateProfessorsByIdResponse(this GetRateProfessorsByIdResult result);
    public static partial GetRateProfessorsByProfessorIdResult ToGetRateProfessorsByProfessorIdResult(this RateProfessorEntity rateProfessor);
    public static partial GetRateProfessorsByProfessorIdResponse ToGetRateProfessorsByProfessorIdResponse(this GetRateProfessorsByProfessorIdResult result);
    public static partial GetRateProfessorsByStudentIdResult ToGetRateProfessorsByStudentIdResult(this RateProfessorEntity rateProfessor);
    public static partial GetRateProfessorsByStudentIdResponse ToGetRateProfessorsByStudentIdResponse(this GetRateProfessorsByStudentIdResult result);
}
