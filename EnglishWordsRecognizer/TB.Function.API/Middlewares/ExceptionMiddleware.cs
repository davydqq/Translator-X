using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.Logging;
using System.Net;

namespace TB.Function.API.Middlewares;

public class ExceptionMiddleware : IFunctionsWorkerMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(FunctionContext context, Exception exception)
    {
        // To access the RequestData
        var req = await context.GetHttpRequestDataAsync();

        // To set the ResponseData
        var res = req!.CreateResponse();
        res.StatusCode = HttpStatusCode.OK;

        var data = new ErrorDetails()
        {
            StatusCode = (int)res.StatusCode,
        }.ToString();

        await res.WriteStringAsync(data);
        context.GetInvocationResult().Value = res;
    }
}
