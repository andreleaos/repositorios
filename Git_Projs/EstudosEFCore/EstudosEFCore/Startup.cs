using EstudosEFCore.Models.Domain.Enums;
using EstudosEFCore.Models.Domain.Setup;
using EstudosEFCore.Models.Infrastructure.Contexts;
using EstudosEFCore.Models.Infrastructure.Repositories;
using EstudosEFCore.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstudosEFCore
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
            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            ConfigureDatabase(services);

            services.AddScoped<VeiculoRepository, VeiculoRepositoryImpl>();
            services.AddScoped<VeiculoService, VeiculoServiceImpl>();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            if (SetupDb.SELECTED_DB.Equals(DatabaseType.SqlServer))
            {
                string sqlConnStr = Configuration.GetConnectionString("SqlServerConnection");
                services.AddDbContext<ControleFrotaContext>(opt => opt.UseSqlServer(sqlConnStr));
            }
            else if(SetupDb.SELECTED_DB.Equals(DatabaseType.MySql))
            {
                string sqlConnStr = Configuration.GetConnectionString("MySqlConnection");
                services.AddDbContext<ControleFrotaContext>(opt => opt.UseMySql(sqlConnStr));
            }
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
