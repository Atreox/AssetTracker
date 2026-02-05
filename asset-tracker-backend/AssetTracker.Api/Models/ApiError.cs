namespace AssetTracker.Api.Models
{
    public sealed record ApiError(
    string TraceId,
    int Status,
    string Code,
    string Message,
    object? Details = null
);

}
