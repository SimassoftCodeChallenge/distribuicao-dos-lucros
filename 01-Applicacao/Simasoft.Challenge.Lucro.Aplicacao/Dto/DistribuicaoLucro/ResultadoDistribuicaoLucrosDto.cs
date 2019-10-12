using System.Collections.Generic;

namespace Simasoft.Challenge.Lucro.Aplicacao.Dto.DistribuicaoLucro
{
    public class ResultadoDistribuicaoLucrosDto
    {
        public float TotalFuncionarios { get; set; }
        public decimal TotalDistribuido { get; set; }
        public decimal TotalDisponibilizado { get; set; }
        public decimal SaldoTotalDisponibilizado { get; set; }
        public List<ParticipacaoDto> Participacoes { get; set; }
    }
}