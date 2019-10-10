using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.DistribuicaoLucro;

namespace Simasoft.Challenge.Lucro.Aplicacao.Contratos
{
    public interface IAplicacaoDistribuicaoLucros
    {
         ResultadoDistribuicaoLucrosDto ExecutaDistribuicao(float valorDisponibilizado,float salarioMinimoNacional);
    }
}