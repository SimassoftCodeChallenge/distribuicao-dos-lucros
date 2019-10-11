using System;

namespace Simasoft.Challenge.Lucro.Api.Models
{
    public class FuncionarioModel
    {
        public long? Matricula { get; set; }        
        public string Nome { get; set; }        
        public string Area { get; set; }       
        public string Cargo { get; set; }        
        public float SalarioBruto { get; set; }        
        public DateTime DataAdmissao { get; set; }
    }
}