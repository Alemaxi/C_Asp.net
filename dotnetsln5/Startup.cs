using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetsln5.Business;
using dotnetsln5.Business.Implementation;
using dotnetsln5.Models.Context;
using dotnetsln5.Repository;
using dotnetsln5.Repository.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;

namespace dotnetsln5
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var strConn = Configuration.GetConnectionString("MySqlConn");

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(strConn);
            }

            services.AddDbContext<Dotnetsln5Context>(options => options.UseMySql(strConn,ServerVersion.AutoDetect(strConn)));

            //Repository
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();

            //Business
            services.AddScoped<IPessoaBusiness, PessoaBusiness>();
            services.AddScoped<IEnderecoBusiness, EnderecoBusiness>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "dotnetsln5", Version = "v1" });
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetsln5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        private void MigrateDatabase(string strConn)
        {
            try
            {
                var evolveConn = new MySql.Data.MySqlClient.MySqlConnection(strConn);
                var evolve = new Evolve.Evolve(evolveConn)
                {
                    Locations = new List<string> { "DB/Migrations", "DB/Migrations" },
                    IsEraseDisabled = true
                };
                evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Conexão com o BD falhou.", ex);
                throw;
            }
        }
    }
}
