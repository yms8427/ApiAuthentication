using BilgeAdam.SecuredApp.Services.Abstractions;
using BilgeAdam.SecuredApp.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilgeAdam.SecuredApp.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
