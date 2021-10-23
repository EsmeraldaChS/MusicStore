using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicStore.Service.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Service.Services;

namespace MusicStore.Api // En esta clase hacemos configuraciones GLOBALES, conf de librarias. IMPORTANTE!
{
    public class Startup
    {
        public Startup(IConfiguration configuration)// Abstrae todo los nodos del appsettings
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Agregar dependencias
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<MusicDBContext>(e => e.UseSqlServer(Configuration.GetConnectionString("ConexionSql")));
            services.AddScoped<IAlbumService, AlbumService>();//albumservice esta adoptando los metodos a IAlbumService, inyectando de AlbumService con IAlbumSercice
            services.AddScoped<ISongService, SongService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
