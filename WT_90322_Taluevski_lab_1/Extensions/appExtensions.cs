using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using WT_90322_Taluevski_lab_1.Middleware;

namespace WT_90322_Taluevski_lab_1.Extensions
{
    public static class appExtensions
    {
        public static IApplicationBuilder UseLogging(this
                                            IApplicationBuilder app)
            => app.UseMiddleware<LogMiddleware>();
    }
}
