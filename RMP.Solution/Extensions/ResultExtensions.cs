using RMP.Host.Abstarctions.Errors;
using RMP.Host.Abstarctions.ResultResponse;

namespace RMP.Host.Extensions;

public static class ResultExtensions
{
    public static T Match<T>(
        this Result result,
        Func<T> onSuccess,
        Func<Error, T> onFailure)
    {
        return result.IsSuccess ? onSuccess() : onFailure(result.Error);
    }
}