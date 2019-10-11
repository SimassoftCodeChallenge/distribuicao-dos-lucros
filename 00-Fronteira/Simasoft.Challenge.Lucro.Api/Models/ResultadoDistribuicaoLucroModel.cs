using System.Collections.Generic;

namespace Simasoft.Challenge.Lucro.Api.Models
{
    public class ResultadoDistribuicaoLucroModel
    {
        public float TotalFuncionarios { get; set; }
        public float TotalDistribuido { get; set; }
        public float TotalDisponibilizado { get; set; }
        public float SaldoTotalDisponibilizado { get; set; }
        public List<ParticipacaoModel> Participacoes { get; set; }
    }
}