using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WKHomeWork.Library.Domain.PracownikAggregate.Services;

namespace WKHomeWork.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Przystosowanie do zastosowania Dependency Injection
            //services.AddScoped<IPracownikRepository, PracownikRepository>();
            //services.AddScoped<INextNumerEwidencyjnyService, NextNumerEwidencyjnyService>();
            //services.AddScoped<IPracownikCreateHandler, PracownikCreateHandler>();
            //services.AddScoped<IPracownikUpdateHandler, PracownikUpdateHandler>();
            //services.AddScoped<IPracownikFactory, PracownikFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
