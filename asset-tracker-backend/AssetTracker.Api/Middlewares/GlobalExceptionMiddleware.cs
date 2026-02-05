using AssetTracker.Api.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AssetTracker.Api.Middlewares
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var traceId = context.TraceIdentifier;

                var (status, code, message, details) = MapException(ex);

                _logger.LogError(ex, "Unhandled exception. TraceId={TraceId}", traceId);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = status;

                var payload = new ApiError(traceId, status, code, message, details);
                await context.Response.WriteAsJsonAsync(payload);
            }
        }

        private static (int status, string code, string message, object? details) MapException(Exception ex)
        {
            

          
            if (ex is DbUpdateException dbEx)
            {
              
                if (dbEx.InnerException is SqlException sqlEx)
                {
                   
                    if (sqlEx.Number == 547)
                    {
                        
                        var msg = "İlişki kısıtı hatası. Gönderilen id geçersiz olabilir (ör: EmployeeId).";
                        return (StatusCodes.Status400BadRequest, "FK_CONSTRAINT", msg, new { sqlEx.Number, sqlEx.Message });
                    }

                   
                    if (sqlEx.Number is 2601 or 2627)
                    {
                        var msg = "Aynı kayıt zaten mevcut (unique constraint).";
                        return (StatusCodes.Status409Conflict, "DUPLICATE", msg, new { sqlEx.Number, sqlEx.Message });
                    }
                }

                return (StatusCodes.Status400BadRequest, "DB_UPDATE_ERROR", "Veritabanı kayıt işlemi başarısız.", null);
            }

            // Auth
            if (ex is UnauthorizedAccessException)
                return (StatusCodes.Status401Unauthorized, "UNAUTHORIZED", "Yetkisiz erişim.", null);

            // Default
            return (StatusCodes.Status500InternalServerError, "ERROR", "Beklenmeyen bir hata oluştu.", null);

        }
    }
}
