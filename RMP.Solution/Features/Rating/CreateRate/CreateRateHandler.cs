using MediatR;
using RMP.Host.Abstarctions.CQRS;
using RMP.Host.Abstarctions.ResultResponse;
using RMP.Host.Database;
using RMP.Host.Features.Rating.CreateRate.Strategy;
using RMP.Host.Features.Rating.Extension.PredictionService.Interface;

namespace RMP.Host.Features.Rating.CreateRate;

public sealed record CreateRateCommand(CreateRateRequest Request) : ICommand<Result<RateResult>>;

public sealed record RateResult(
    Guid Id,
    Guid EntityId,
    int UserId,
    int Overall,
    string Feedback,
    int? CommunicationSkills,
    int? Responsiveness,
    int? GradingFairness);

public class CreateRateCommandHandler(ApplicationDbContext dbContext, RateHandlerStrategyResolver strategyResolver, IPredictionService predictionService)
    : IRequestHandler<CreateRateCommand, Result<RateResult>>
{
    public async Task<Result<RateResult>> Handle(CreateRateCommand request, CancellationToken cancellationToken)
    {
        var predictionResult = predictionService.PredictToxicityAsync(request.Request.Feedback);
        if (predictionResult.Result.IsToxic)
            return Result.Failure<RateResult>(RatingErrors.IsToxic(predictionResult.Result.Message));

        var strategy = strategyResolver.Resolve(request.Request.EntityType);
        return await strategy.HandleAsync(request.Request, dbContext, cancellationToken);
    }
}

public class RateHandlerStrategyResolver(IServiceProvider serviceProvider)
{
    public IRateHandlerStrategy Resolve(string entityType) => entityType.ToLower() switch
    {
        "professor" => serviceProvider.GetRequiredService<ConcreteRateProfessorStrategy>(),
        "university" => serviceProvider.GetRequiredService<ConcreteRateUniversityStrategy>(),
        _ => throw new NotImplementedException($"No strategy found for entity type: {entityType}")
    };
}

