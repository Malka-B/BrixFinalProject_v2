using Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Account.WebApi.Miidleware
{
    public class AccountErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public AccountErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
                if (context.Response.StatusCode == StatusCodes.Status401Unauthorized)
                {
                    throw new UnauthorizedAccessException("Password or Email are not correct. try again!");
                }
                if (context.Response.StatusCode == StatusCodes.Status400BadRequest)
                {
                    throw new UnauthorizedAccessException("Action Failed. Please try again!");
                }
            }
            catch (AccountNotFoundException ex)
            {
                await HandleExceptionsAsync(context, ex);
            }
        }
        public async Task HandleExceptionsAsync(HttpContext context, Exception ex)
        {
            var code = new HttpStatusCode();
            if (ex is AccountNotFoundException) code = HttpStatusCode.NotFound;
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
          //  return await context.Response.WriteAsync(result);
        }
    }
}
