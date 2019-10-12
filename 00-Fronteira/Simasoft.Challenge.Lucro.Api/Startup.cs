using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Simasoft.Challenge.Lucro.Api.Utils.Providers;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Config;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.IoC.Aplicacao;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.IoC.Dominio;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Repositorio;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using System;

namespace Simasoft.Challenge.Lucro.Api
{
    public class Startup
    {
        private ConfiguracaoAplicacao _config;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }                
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
            });

            _config = CriaObjetoConfiguracao();
            ExecutaInjecaoDeDependencia(services,_config);

            services.AddDistributedMemoryCache();
            services.Configure<FormOptions>(x => x.ValueCountLimit = 1000000);
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {
                     Version = "v1",
                     Title = "Desafio - Distribuição dos lucros",
                     Description = "Desafio - Distribuição dos lucros"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {            
            //app.UseHttpsRedirection();
            //app.UseStaticFiles();
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio - Distribuição dos lucros");                
            });
            app.UseResponseCompression();
        }

        private ConfiguracaoAplicacao CriaObjetoConfiguracao(){
            string instancia = Configuration.GetValue<string>("CurrentDatabaseName");
            var database = instancia;
            var config = new ConfiguracaoAplicacao();
            Configuration.Bind(database,config);     
            return config;                            
        }

        private void ExecutaInjecaoDeDependencia(IServiceCollection services, ConfiguracaoAplicacao config){
            services.AdicionarInjecaoDependenciaDominio();
            services.AdicionarInjecaoDependenciaRepositorio(config);            
            services.AdicionarInjecaoDependenciaAplicacao();
        }
    }
}
