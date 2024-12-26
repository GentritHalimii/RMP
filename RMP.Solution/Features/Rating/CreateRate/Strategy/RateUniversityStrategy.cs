using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Entities;

namespace RMP.Host.Features.Rating.CreateRate.Strategy;

public class ConcreteRateProfessorStrategy : RateProfessorStrategy
{
    
}

public abstract class RateUniversityStrategy : IRateHandlerStrategy
{
    public async Task<Result<RateResult>> HandleAsync(CreateRateRequest request, ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        var rateUniversity = new RateUniversityEntity
        {
            Id = Guid.NewGuid(),
            UniversityId = request.EntityId,
            UserId = request.UserId,
            Overall = request.Overall,
            Feedback = request.Feedback
        };

        dbContext.RateUniversities.Add(rateUniversity);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new RateResult(rateUniversity.Id, request.EntityId, request.UserId, request.Overall, request.Feedback, null, null, null);
    }
}