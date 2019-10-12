using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Config;
using Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios;

namespace Simasoft.Challenge.Lucro.Infra.CrossCutting.Repositorio
{
    public static class InjecaoDependenciaRepositorio
    {
        public static IServiceCollection AdicionarInjecaoDependenciaRepositorio(this IServiceCollection servicos, ConfiguracaoAplicacao config)
        {
            servicos.AddSingleton(config);
            servicos.AddSingleton<IRepositorioFuncionario, RepositorioFuncionario>(sp =>
            {                   
                var _connectionStrings = ExtraiConnectionStrings(sp);
                return new RepositorioFuncionario(_connectionStrings);
            });

            servicos.AddSingleton<IRepositorioFuncionarioAsync, RepositorioFuncionarioAsync>(sp =>
            {                        
                var _connectionStrings = ExtraiConnectionStrings(sp);
                return new RepositorioFuncionarioAsync(_connectionStrings);
            });
            return servicos;
        }

        public static string ExtraiConnectionStrings(IServiceProvider sp){
            var config = sp.GetRequiredService<ConfiguracaoAplicacao>();
                var relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
                return $"{config.DatabaseConnection.Replace("..",relativePath)}";
        }        
    }
}
