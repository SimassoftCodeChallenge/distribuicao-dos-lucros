using System.Collections.Generic;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros;

namespace Simasoft.Challenge.Lucro.Dominio.Servicos.DistribuicaoLucros
{
    public class ServicoDominioDistribuicaoLucros: IServicoDominioDistribuicaoLucros
    {
        public DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Participacao> participantes, float valorDisponibilizado, float salarioMinimoNacional)
        {
            var _distribuicaoLucros = new DistribuicaoLucro(participantes, valorDisponibilizado, salarioMinimoNacional);
            return _distribuicaoLucros;
        }        
    }
}