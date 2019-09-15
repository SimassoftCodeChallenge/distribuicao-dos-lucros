using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tdd.Simasoft.Challenge.Lucro.Tdd.Persistencia.Entidades
{
    public class Funcionario: EntidadeBase
    {                
        public long? Matricula { get; set; }

        public string Nome { get; set; }

        public string Area { get; set; }

        public string Cargo { get; set; }

        public float SalarioBruto { get; set; }

        public DateTime DataAdmissao { get; set; }

        public bool Estagiario { get; set; }
    }
}
