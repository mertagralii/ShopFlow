using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ShopFlow.API.Middleware;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Beklenmeyen Hata : {Message}", exception.Message);
        var (statusCode, title, detail) = exception switch
        {
            ArgumentException => (StatusCodes.Status400BadRequest, "Geçersiz Argüman", exception.Message),
            KeyNotFoundException => (StatusCodes.Status404NotFound, "Kayıt Bulunamadı", exception.Message),
            _ => (StatusCodes.Status500InternalServerError, "Sunucu Hatası", "Beklenmeyen bir hata oluştu.")
        };
        var problem = new ProblemDetails { Status = statusCode, Title = title, Detail = detail };
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken);
        return true;
    }
}