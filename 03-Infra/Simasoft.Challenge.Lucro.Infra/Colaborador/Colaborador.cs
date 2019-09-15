using Simasoft.Challenge.Lucro.Infra.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Infra.Colaborador
{
    public class Colaborador: EntidadeBase
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
