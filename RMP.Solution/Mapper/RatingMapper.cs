using Riok.Mapperly.Abstractions;
using RMP.Host.Entities;
using RMP.Host.Features.Rating.GetRateProfessors;
using RMP.Host.Features.Rating.GetRateUniversities;

namespace RMP.Host.Mapper;

[Mapper]
public static partial class RatingMapper
{
    public static partial GetRateProfessorsResult ToGetRateProfessorsResult(this RateProfessorEntity rateProfessor);
    public static partial GetRateProfessorsResponse ToGetRateProfessorsResponse(this GetRateProfessorsResult result);
    public static partial GetRateUniversitiesResult ToGetRateUniversitiesResult(this RateUniversityEntity rateUniversity);
    public static partial GetRateUniversitiesResponse ToGetRateUniversitiesResponse(this GetRateUniversitiesResult result);
}
