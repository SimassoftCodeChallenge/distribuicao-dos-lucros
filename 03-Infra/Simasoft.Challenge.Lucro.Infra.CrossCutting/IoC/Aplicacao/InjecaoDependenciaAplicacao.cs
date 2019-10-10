using Microsoft.Extensions.DependencyInjection;
using Simasoft.Challenge.Lucro.Aplicacao.Contratos;
using Simasoft.Challenge.Lucro.Aplicacao.Servicos;

namespace Simasoft.Challenge.Lucro.Infra.CrossCutting.IoC.Aplicacao
{
    public static class InjecaoDependenciaAplicacao
    {
        public static IServiceCollection AdicionarInjecaoDependenciaAplicacao(this IServiceCollection servicos)
        {            
            servicos.AddScoped<IAplicacaoDistribuicaoLucros,ServicoAplicacaoDistribuicaoLucros>();
            servicos.AddScoped<IAplicacaoFuncionario,ServicoAplicacaoFuncionario>();
            return servicos;
        }
    }
}