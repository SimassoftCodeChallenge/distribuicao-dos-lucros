using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros
{
    public class ServicoDominioDistribuicaoLucro : IServicoDominioDistribuicaoLucros
    {        
        public DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Participacao> participantes, float valorDisponibilizado, float salarioMinimoNacional)
        {
            var _distribuicaoLucros = new DistribuicaoLucro(participantes, valorDisponibilizado, salarioMinimoNacional);
            return _distribuicaoLucros;
        }
    }
}
