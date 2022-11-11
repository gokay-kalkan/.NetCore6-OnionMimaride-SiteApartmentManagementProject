
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace ApartmentManagement.Application.GlobalExceptionsLogs
{
    public class GlobalExceptionsLogsMiddleware
    {
        private readonly RequestDelegate _next;
        ILogger<GlobalExceptionsLogsMiddleware> _logger;


        public GlobalExceptionsLogsMiddleware(RequestDelegate next, ILogger<GlobalExceptionsLogsMiddleware> logger)
        {
            _next = next;
            _logger = logger;

        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                string message = "{Request} HTTP " + context.Request.Method + "-" + context.Request.Path;
                message += "{İp Address} " + context.Connection.RemoteIpAddress;
                await _next(context);
                _logger.LogDebug(message);

                message = "{Response} HTTP " + context.Request.Method + "-" + context.Request.Path + "responded" + context.Response.StatusCode;

                message += "{İp Address} " + context.Connection.RemoteIpAddress.MapToIPv4().ToString();

                _logger.LogDebug(message);

                Console.WriteLine(message);
            }

            catch (Exception exception)
            {
               
                string message = "{Request} HTTP " + context.Request.Method + "-" + context.Request.Path;

                message += "{İp Address} " + context.Connection.RemoteIpAddress.MapToIPv4().ToString();
                _logger.LogError(message);

                message = "{Response} HTTP " + context.Request.Method + "-" + context.Request.Path + "responded" + context.Response.StatusCode;

                message += "{İp Address} " + context.Connection.RemoteIpAddress.MapToIPv4().ToString();

                message += exception.Message;

                _logger.LogError(message);

            }
        }
       

    }
}
