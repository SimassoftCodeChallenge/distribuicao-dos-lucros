using Microsoft.Extensions.DependencyInjection;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios;

namespace Simasoft.Challenge.Lucro.Infra.CrossCutting.Repositorio
{
    public static class InjecaoDependenciaRepositorio
    {
        public static IServiceCollection AdicionarInjecaoDependenciaRepositorio(this IServiceCollection servicos, string connectionStrings)
        {
            servicos.AddSingleton<IRepositorioFuncionario, RepositorioFuncionario>(sp =>
            {                
                return new RepositorioFuncionario(connectionStrings);
            });

            servicos.AddSingleton<IRepositorioFuncionarioAsync, RepositorioFuncionarioAsync>(sp =>
            {                
                return new RepositorioFuncionarioAsync(connectionStrings);
            });
            return servicos;
        }
    }
}
