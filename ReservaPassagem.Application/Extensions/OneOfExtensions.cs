using OneOf;
using ReservaPassagem.Application.Errors;

namespace ReservaPassagem.Application.Extensions;

public static class OneOfExtensions
{
    public static bool IsSucess<TResult>(this OneOf<TResult, AppError> obj) => obj.IsT0;
    public static TResult GetSucessResult<TResult>(this OneOf<TResult,AppError> obj) => obj.AsT0;
    
    public static bool IsError<TResult>(this OneOf<TResult, AppError> obj) => obj.IsT1;
    public static AppError GetErrorResult<TResult>(this OneOf<TResult, AppError> obj) => obj.AsT1;
}