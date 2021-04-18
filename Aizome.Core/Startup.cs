using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Aizome.Core.DataAccess;
using Aizome.Core.DataAccess.Repositories;
using Aizome.Core.DataAccess.Repositories.Postgres;
using Aizome.Core.Services;
using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;

namespace Aizome.Core
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aizome.Core", Version = "v1" });
            });

            services.AddDbContext<AizomeContext>(options =>
                options.UseNpgsql(Configuration["AizomeConnection"]));

            services.AddSingleton(x =>
                new BlobServiceClient(Configuration["AzureBlobConnectionString"]));

            services.AddScoped<IUserRepository, UserPgRepository>();
            services.AddScoped<IJeanRepository, JeanPgRepository>();
            services.AddScoped<ITimelineRepository, TimelinePgRepository>();
            services.AddScoped<IBlobRepository, BlobPgRepository>();

            services.AddScoped<IBlobService, BlobService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Aizome.Core v1"));
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
