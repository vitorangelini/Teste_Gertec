using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gertec.CrossCutting.Middleware;

namespace Gertec.CrossCutting.DependencyInjection
{
    public static class  MiddlewareExtensions
    {
        public static IApplicationBuilder UseMeuMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
