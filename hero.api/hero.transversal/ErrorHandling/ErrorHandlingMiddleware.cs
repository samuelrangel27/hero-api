using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using hero.transversal.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace hero.transversal.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> logger;

        public ErrorHandlingMiddleware(RequestDelegate next
            ,ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            HttpStatusCode code = HttpStatusCode.OK;
            try
            {
                using (var responseBody = new MemoryStream())
                {
                    //...and use that for the temporary response body
                    context.Response.Body = responseBody;
                    await _next(context);
                    context.Response.Body.Position = 0;
                    var bodyText = await new StreamReader(context.Response.Body).ReadToEndAsync();
                    dynamic apiResult = JsonConvert.DeserializeObject<object>(bodyText);
                    
                    switch (apiResult.State)
                    {
                        case ResultState.BusinessValidationError:
                            code = HttpStatusCode.BadGateway;
                            break;
                        case ResultState.ElementNotFound:
                            code = HttpStatusCode.NotFound;
                            break;
                        default:
                            code = HttpStatusCode.OK;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogCritical(ex.Message);
                code = HttpStatusCode.InternalServerError;
            }
            finally {
                context.Response.StatusCode = (int)code;
            }
        }

    }
}
