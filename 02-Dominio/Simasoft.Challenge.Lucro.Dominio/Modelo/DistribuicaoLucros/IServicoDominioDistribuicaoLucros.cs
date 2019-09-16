using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros
{
    public interface IServicoDominioDistribuicaoLucros
    {
        DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Participacao> participantes, float valorDisponibilizado, float salarioMinimoNacional);
    }
}
