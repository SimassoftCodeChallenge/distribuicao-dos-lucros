using Microsoft.Extensions.DependencyInjection;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using Simasoft.Challenge.Lucro.Infra.Funcionario;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Infra.Config
{
    public static class InjecaoDependenciaRepositorio
    {
        public static IServiceCollection AdicionarInjecaoDependenciaRepositorio(this IServiceCollection servicos, string connectionStrings)
        {
            servicos.AddSingleton<IRepositorioFuncionario, RepositorioFuncionario>(sp =>
            {                
                return new RepositorioFuncionario(connectionStrings);
            });
            return servicos;
        }
    }
}
