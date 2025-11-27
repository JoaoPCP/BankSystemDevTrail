using Microsoft.AspNetCore.Diagnostics;
using ProjetoDevTrail.Application.Utils.Exceptions;

namespace ProjetoDevTrail.Api.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
        )
        {
            if (exception is ExceptionWithStatusCode exceptionWithStatusCode)
            {
                _logger.LogWarning(
                    exception,
                    $"A handled exception occurred with status code {exceptionWithStatusCode.StatusCode}"
                );
                httpContext.Response.StatusCode = exceptionWithStatusCode.StatusCode;
                await httpContext.Response.WriteAsJsonAsync(
                    new { message = exceptionWithStatusCode.Message },
                    cancellationToken
                );
                return true;
            }
            _logger.LogError(exception, "An unhandled exception occurred.");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(
                new { message = "Ocorreu um erro, tente novamente mais tarde" },
                cancellationToken
            );
            return true;
        }
    }
}
