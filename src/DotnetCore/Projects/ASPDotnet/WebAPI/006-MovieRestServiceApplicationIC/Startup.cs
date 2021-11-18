using CSD.MovieRestServiceApplication.DAL;
using CSD.MovieRestServiceApplication.Data;
using CSD.MovieRestServiceApplication.Data.Repositories;
using CSD.MovieRestServiceApplication.Data.Service;
using CSD.Util.Mappers;
using CSD.Util.Mappers.Mapster;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MovieRestServiceApplication
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
                .AddSingleton<MovieAppDbContext>()
                .AddSingleton<IMovieRepository, MovieRepository>()
                .AddSingleton<IDirectorRepository, DirectorRepository>()  
                .AddSingleton<MoviesDataHelper>()
                .AddSingleton<IMapper, Mapper>()
                .AddSingleton<MoviesService>();
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
