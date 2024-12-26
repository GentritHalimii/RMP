using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;

namespace RMP.Host.Features.Rating.CreateRate.Strategy;

public interface IRateHandlerStrategy
{
    Task<Result<RateResult>> HandleAsync(CreateRateRequest request, ApplicationDbContext dbContext, CancellationToken cancellationToken);
}