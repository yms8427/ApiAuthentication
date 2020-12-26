using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BilgeAdam.SecuredApp.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<NorthwindContext>(builder =>
            {
                builder.UseSqlServer(connectionString);
            });
        }
    }
}