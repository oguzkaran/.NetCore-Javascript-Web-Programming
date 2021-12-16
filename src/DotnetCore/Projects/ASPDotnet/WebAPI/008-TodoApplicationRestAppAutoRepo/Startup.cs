using CSD.TodoApplicationRestApp;
using CSD.TodoApplicationRestApp.DAL;
using CSD.TodoApplicationRestApp.Data;
using CSD.TodoApplicationRestApp.Repositories;
using CSD.Util.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
