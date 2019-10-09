namespace Simasoft.Challenge.Lucro.Aplicacao.Dto.DistribuicaoLucro
{
    public class ResultadoDistribuicaoLucrosDto
    {
        public float TotalFuncionarios { get; set; }
        public float TotalDistribuido { get; set; }
        public float TotalDisponibilizado { get; set; }
        public float SaltoTotalFuncionarios { get; set; }
        public ParticipacaoDto Participacoes { get; set; }
    }
}