using System;
using System.Threading.Tasks;
using FootBall.Infrastructure.Services.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace FootBall.Web.Middleware
{
    public class SessionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<SessionMiddleware> _logger;
        private readonly ISessionProvider _session;

        public SessionMiddleware(RequestDelegate next, ILogger<SessionMiddleware> logger, ISessionProvider session)
        {
            _next = next;
            _logger = logger;
            _session = session;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                _logger.LogInformation("Open Session");
                _session.OpenSession();
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _session.CloseSession();
                _logger.LogError(ex, $"An error occurred while executing the session. Error stack: {ex.Message}");
            }
            finally
            {
                _session.CloseSession();
                _logger.LogInformation("Close Session");
            }
        }
    }
}