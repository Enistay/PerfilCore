using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PerfilCore.Infra;
using PerfilCore.Infra.Repositorio;
using PerfilCore.Interfaces;
using PerfilCore.Services;

namespace PerfilCore
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
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddControllers();
            
            services.AddDbContextPool<PerfilCoreContext>(options => options.UseSqlServer(Configuration.GetSection("Configuracoes:StringConexao").Value));
            services.AddScoped<PerfilCoreContext, PerfilCoreContext>();

            #region Serviços e Repositórios

            services.AddScoped<IServiceCadastro, ServiceCadastro>();
            services.AddScoped<IServicePerfil, ServicePerfil>();

            services.AddScoped<IRepositoryBase, RepositoryBase>();
            #endregion
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

            app.UseCors(c => { c.AllowAnyHeader(); c.AllowAnyMethod(); c.AllowAnyOrigin(); });

            //app.UseSwagger();

            //app.Use.SwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "PerfilCore - V1"); });

        }
    }
}
