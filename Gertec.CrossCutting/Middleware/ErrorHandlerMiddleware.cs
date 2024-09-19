using Gertec.Application.Exceptions;
using Gertec.Application.Interfaces.External;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gertec.CrossCutting.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var logService = context.RequestServices.GetService<ILogService>();

            try
            {
                await _next(context);
            }
            catch (BusinessException businessEx)
            {
                await HandleBusinessExceptionAsync(context, businessEx);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, logService);
                throw; 
            }
        }

        private async Task HandleBusinessExceptionAsync(HttpContext context, BusinessException businessEx)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var result = new
            {
                mensagem = businessEx.Message,
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, ILogService logService)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            if (logService != null)
                await logService.IncluirLog(ex); 

            var result = new
            {
                mensagem = "Ocorreu um erro interno. Tente novamente mais tarde."
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }

}
