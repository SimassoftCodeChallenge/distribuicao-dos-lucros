using System.Collections.Generic;
using Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros;

namespace Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos
{
    public interface IServicoDominioDistribuicaoLucros
    {
         DistribuicaoLucro ExecutaDistribuicaoDosLucros(List<Participacao> participantes, float valorDisponibilizado, float salarioMinimoNacional);
    }
}