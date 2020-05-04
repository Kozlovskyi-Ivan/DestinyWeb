using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Destiny_back.Modules;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.IO;

namespace Destiny_back
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
            //string con = @"Server=(localdb)\mssqllocaldb;Database=Destinytest01;Trusted_Connection=True;";
            //string con = File.ReadAllText(@"\\DefaultConnection.txt");@"Server=destiny-back-sql,1433;Database=Destiny;User Id=SA;Password=MyPassword001;"
            //string con = (@"Server=localhost,1433;Database=Destiny;User Id=SA;Password=MyPassword001;");
            string con = (@"Server=destiny-back-sql,1433;Database=Destiny;User Id=SA;Password=MyPassword001;");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(con));
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<ApplicationContext>().Database.Migrate();
            }
            app.UseCors(options => options.WithOrigins("http://localhost:1300").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("http://localhost:8000").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("http://destiny-front:8000").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("http://destiny-front:1300").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("destiny-front:8000").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("destiny-front:1300").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("http://destiny-front").AllowAnyMethod().AllowAnyHeader());
            app.UseCors(options => options.WithOrigins("destiny-front").AllowAnyMethod().AllowAnyHeader());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
