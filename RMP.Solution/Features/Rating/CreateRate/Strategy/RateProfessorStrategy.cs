using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Entities;

namespace RMP.Host.Features.Rating.CreateRate.Strategy;

public class ConcreteRateUniversityStrategy : RateUniversityStrategy
{
    
}

public abstract class RateProfessorStrategy : IRateHandlerStrategy
{
    public async Task<Result<RateResult>> HandleAsync(CreateRateRequest request, ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        var rateProfessor = new RateProfessorEntity
        {
            Id = Guid.NewGuid(),
            ProfessorId = request.EntityId,
            UserId = request.UserId,
            Overall = request.Overall,
            Feedback = request.Feedback,
            CommunicationSkills = request.CommunicationSkills,
            Responsiveness = request.Responsiveness,
            GradingFairness = request.GradingFairness
        };

        dbContext.RateProfessors.Add(rateProfessor);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new RateResult(rateProfessor.Id, request.EntityId, request.UserId, request.Overall, request.Feedback, rateProfessor.CommunicationSkills, rateProfessor.Responsiveness, rateProfessor.GradingFairness);
    }
}