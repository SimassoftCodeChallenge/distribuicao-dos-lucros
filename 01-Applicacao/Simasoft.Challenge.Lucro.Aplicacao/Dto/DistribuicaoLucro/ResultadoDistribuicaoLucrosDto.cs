using System.Collections.Generic;

namespace Simasoft.Challenge.Lucro.Aplicacao.Dto.DistribuicaoLucro
{
    public class ResultadoDistribuicaoLucrosDto
    {
        public float TotalFuncionarios { get; set; }
        public float TotalDistribuido { get; set; }
        public float TotalDisponibilizado { get; set; }
        public float SaldoTotalDisponibilizado { get; set; }
        public List<ParticipacaoDto> Participacoes { get; set; }
    }
}