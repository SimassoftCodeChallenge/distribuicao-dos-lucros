using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Infra.Funcionario
{
   public class Entidade
   {
        public long? Id { get; set; }
        public long? Matricula { get; private set; }        
        public string Nome { get; private set; }        
        public string Area { get; private set; }       
        public string Cargo { get; private set; }        
        public float SalarioBruto { get; private set; }        
        public DateTime DataAdmissao { get; private set; }
        public bool Estagiario { get; set; }
    }
}
