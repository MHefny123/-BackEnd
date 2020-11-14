using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using Microsoft.OpenApi.Models;

namespace BackEnd
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
            services.AddDbContextPool<MHefny_TaskDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MHefny_Task")));  
            
              
              
            services.AddSwaggerGen(c =>
            {
               c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger Demo", Version = "v1" });
            });
        }  
  
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)  
        {  
            if (env.IsDevelopment())  
            {  
                app.UseDeveloperExceptionPage();  
            }  
            app.UseCors(builder => builder  
              .AllowAnyHeader()  
              .AllowAnyMethod()  
              .SetIsOriginAllowed((host) => true)  
              .AllowCredentials()  
              );  
            app.UseHttpsRedirection();             
            app.UseRouting();  
            app.UseAuthorization();  


             app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger  Demo V1");
            });

  
            app.UseEndpoints(endpoints =>  
            {  
                endpoints.MapControllers();  
            });  
  
            
  
        }  
    }  
}  