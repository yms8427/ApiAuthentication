using BilgeAdam.SecuredApp.Data.Extensions;
using BilgeAdam.SecuredApp.Extensions;
using BilgeAdam.SecuredApp.Services.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BilgeAdam.SecuredApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("all", pb => { pb.AllowAnyOrigin().AllowAnyHeader(); }));
            services.Configure<Settings>(Configuration.GetSection("Settings"));
            services.AddDataServices(Configuration.GetConnectionString("Northwind"));
            services.AddBusinessServices();
            services.AddJwt(Configuration.GetSection("Settings:AuthenticationKey").Value);
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("all");
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}