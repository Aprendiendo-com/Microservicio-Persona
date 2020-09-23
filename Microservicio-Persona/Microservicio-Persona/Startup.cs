using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microservicio_Persona.AccessData;
using SqlKata.Compilers;
using System.Data;
using System.Data.SqlClient;
using Microservicio_Persona.Domain.Command;
using Microservicio_Persona.AccessData.Command;
using Microservicio_Persona.Aplication.Services;
using DocumentFormat.OpenXml.InkML;

namespace Microservicio_Persona
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


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
            var connectionString = Configuration.GetSection("ConnectionString").Value; //busca las configuraciones del sistema
            services.AddDbContext<DbContexto>(options => options.UseSqlServer(connectionString));
            // SQLKATA
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });


            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IEstudianteService, EstudianteService>();
            services.AddTransient<IProfesorService, ProfesorService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;

            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


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