using Microsoft.Extensions.DependencyInjection;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Dominio.Servicos.DistribuicaoLucros;
using Simasoft.Challenge.Lucro.Dominio.Servicos.Funcionario;

namespace Simasoft.Challenge.Lucro.Infra.CrossCutting.IoC.Dominio
{
    public static class InjecaoDependenciaDominio
    {
        public static IServiceCollection AdicionarInjecaoDependenciaDominio(this IServiceCollection servicos)
        {            
            servicos.AddScoped<IServicoDominioFuncionario,ServicoDominioFuncionario>();
            servicos.AddScoped<IServicoDominioDistribuicaoLucros,ServicoDominioDistribuicaoLucros>();
            return servicos;
        }
    }
}
