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
using MySQL.Data.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpClinicoApi
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
            //services.Add(new ServiceDescriptor(typeof(DbContextSystem),
            //    new DbContextSystem(Configuration.GetConnectionString("DefaultConnection"))
            //   )
            //  );
            //services.AddDbContextPool<DbContextSystem>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<DbContextSystem>();
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Todos",
            //        builder => builder.WithOrigins("*").WithHeaders("*").WithMethods("*"));
            //});
            services.AddCors(
                options =>
                {
                    options.AddPolicy("Todos", 
                        builder => builder.WithOrigins("*")
                        .WithHeaders("*")
                        .WithMethods("*"));
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("Todos");

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
