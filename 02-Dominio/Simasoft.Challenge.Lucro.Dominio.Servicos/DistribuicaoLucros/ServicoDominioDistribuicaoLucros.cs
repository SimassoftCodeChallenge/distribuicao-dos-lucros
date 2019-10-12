using System.Collections.Generic;
using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;

namespace Simasoft.Challenge.Lucro.Dominio.Servicos.DistribuicaoLucros
{
    public class ServicoDominioDistribuicaoLucros: IServicoDominioDistribuicaoLucros
    {
        public DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Participacao> participantes, decimal valorDisponibilizado, float salarioMinimoNacional)
        {            
            return new DistribuicaoLucro(participantes, valorDisponibilizado, salarioMinimoNacional);
        }

        public DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Modelo.QuadroFuncionarios.Funcionario> funcionarios, decimal valorDisponibilizado, float salarioMinimoNacional)
        {
            return new DistribuicaoLucro(funcionarios,valorDisponibilizado,salarioMinimoNacional);
        }
    }
}