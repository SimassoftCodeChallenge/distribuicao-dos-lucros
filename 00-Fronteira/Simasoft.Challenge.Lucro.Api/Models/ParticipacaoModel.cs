using Newtonsoft.Json;

namespace Simasoft.Challenge.Lucro.Api.Models
{
    public class ParticipacaoModel
    {
        public long? Matricula { get; set; }
        public string Nome { get; set; }
        [JsonProperty("valor_da_participação")]
        public float ValorParticipacao {get; set;}
    }
}