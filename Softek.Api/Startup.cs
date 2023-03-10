using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softtek.Entity;
using Softtek.Entity.Modelo;
using Microsoft.EntityFrameworkCore;
using Softtek.Entity.Aut;

namespace Softek.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddDbContext<E_VendedorrContext>(options =>
            options.UseInMemoryDatabase("MyDb"));
            services.AddDbContext<E_TokenContext>(options2 =>
           options2.UseInMemoryDatabase("MyDb"));            
            services.AddDbContext<E_VentasContext>(options4 =>
           options4.UseInMemoryDatabase("MyDb"));

            services.AddMvc();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "api v1");

            //});

            //app.UseStaticFiles();
            //app.UseHttpsRedirection();
            //app.UseCors(MyAllowSpecificOrigins);
            //app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();


            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});

        }
    }
}
