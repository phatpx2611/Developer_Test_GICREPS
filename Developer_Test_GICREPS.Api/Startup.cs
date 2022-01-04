using Developer_Test_GICREPS.Application;
using Developer_Test_GICREPS.Infrastructure;
using Developer_Test_GICREPS.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Developer_Test_GICREPS.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCoreWebApiService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GicContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
            services.AddControllers();
            services.AddHttpClient();
            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreWebApiService", Version = "v1" });
            });
            services.AddCors(opt => {
                opt.AddPolicy("CorsPolicy", policy => {
                    policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
                });
            });
        }
    }
}
