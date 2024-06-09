using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace RestfulApi.Middlewares
{
    public class SuperHeaderMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SuperHeaderMiddleware> _logger;

        public SuperHeaderMiddleware(RequestDelegate next, ILogger<SuperHeaderMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.TryGetValue("HEADER", out var headerValue))
            {
                _logger.LogInformation($"Request Header: {headerValue}");
            }
            else
            {
                _logger.LogWarning("HEADER not found");
            }

            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add("ANOTHER", "Nothing");
                return Task.CompletedTask;
            });

            await _next(context);
        }
    }
}
