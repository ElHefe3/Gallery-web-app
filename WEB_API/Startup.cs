using LOGIC.Services.Implementation;
using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

namespace Gettoe_Elementary
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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gettoe_Elementary", Version = "v1" });
            });
            #region CUSTOM SERVICES [D-I]
            services.AddScoped<IA_Permission_Service, A_Permission_Service>();
            services.AddScoped<IAlbum_Service, Album_Service>();
            services.AddScoped<II_Permission_Service, I_Permission_Service>();
            services.AddScoped<IImage_Service, Image_Service>();
            services.AddScoped<IUser_Service, User_Service>();
            #endregion

            #region CORS
            services.AddCors();

            string corsUrl = Configuration["CORS:site"];
            string[] corsUrls;
            if (corsUrl.Contains(","))
            {
                corsUrls = corsUrl.Split(',').ToArray();
            }
            else
            {
                corsUrls = new string[1];
                corsUrls[0] = corsUrl;
            }
            services.AddCors(options =>
            {
                options.AddPolicy("angular",
                    builder =>
                    {
                        builder.WithOrigins(corsUrls)
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gettoe_Elementary v1"));
            }

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
