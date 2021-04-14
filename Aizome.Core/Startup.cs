using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aizome.Core.DataAccess;
using Aizome.Core.DataAccess.Entities;
using Aizome.Core.DataAccess.Repositories;
using Aizome.Core.DataAccess.Repositories.Postgres;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Aizome.Core", Version = "v1" });
            });

            services.AddDbContext<AizomeContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("AizomeConnection")));

            services.AddScoped<IUserRepository, UserPgRepository>();
            services.AddScoped<IJeanRepository, JeanPgRepository>();
            services.AddScoped<ITimelineRepository, TimelinePgRepository>();
            services.AddScoped<IBlobRepository, BlobPgRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
