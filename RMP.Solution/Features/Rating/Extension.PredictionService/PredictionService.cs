using RMP.Host.Features.Rating.Extension.PredictionService.Interface;

namespace RMP.Host.Features.Rating.Extension.PredictionService;

public class PredictionService(RMP.Host.PredictionService.PredictionServiceClient grpcClient)
    : IPredictionService
{
    public async Task<PredictionResult> PredictToxicityAsync(string feedback)
    {
        var request = new PredictionRequest { SentimentText = feedback };
        var response = grpcClient.PredictToxicity(request);

        return new PredictionResult
        {
            IsToxic = response.IsToxic,
            Message = response.Message
        };
    }
}