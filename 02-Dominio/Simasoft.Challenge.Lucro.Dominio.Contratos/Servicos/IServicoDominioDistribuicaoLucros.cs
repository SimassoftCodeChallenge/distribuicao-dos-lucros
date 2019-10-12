using System.Collections.Generic;
using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;

namespace Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos
{
    public interface IServicoDominioDistribuicaoLucros
    {
         DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Participacao> participantes, decimal valorDisponibilizado, float salarioMinimoNacional);
         DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Funcionario> funcionarios, decimal valorDisponibilizado, float salarioMinimoNacional);
    }
}