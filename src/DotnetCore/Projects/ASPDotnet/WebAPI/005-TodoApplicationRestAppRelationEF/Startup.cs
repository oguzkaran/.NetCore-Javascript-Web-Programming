using CSD.TodoApplicationRestApp;
using CSD.TodoApplicationRestApp.Configuration;
using CSD.TodoApplicationRestApp.DAL;
using CSD.TodoApplicationRestApp.Data;
using CSD.TodoApplicationRestApp.Repositories;
using CSD.Util.Mappers;
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

namespace _001_TodoApplicationRestApp
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

            services
                .AddSingleton<ConnectionConfig>() //deprecated
                .AddSingleton<ITodoRepository, TodoRepository>()
                .AddSingleton<IItemRepository, ItemRepository>()
                .AddSingleton<TodoAppDAL>()
                .AddSingleton<TodoAppService>()
                .AddSingleton<TodoDbContext>()
                .AddSingleton<IMapper, CSD.Util.Mappers.Mapster.Mapper>();                
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
