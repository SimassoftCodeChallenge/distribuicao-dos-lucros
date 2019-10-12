using System.Collections.Generic;
using Newtonsoft.Json;

namespace Simasoft.Challenge.Lucro.Api.Models
{
    public class ResultadoDistribuicaoLucroModel
    {                        
        [JsonProperty("total_de_funcionarios")]        
        public float TotalFuncionarios { get; set; }

        [JsonProperty("total_distribuido")]
        public decimal TotalDistribuido { get; set; }

        [JsonProperty("total_disponibilizado")]
        public decimal TotalDisponibilizado { get; set; }

        [JsonProperty("saldo_total_disponibilizado")]
        public decimal SaldoTotalDisponibilizado { get; set; }

        [JsonProperty(Order = -5)]
        public List<ParticipacaoModel> Participacoes { get; set; }
        
    }
}