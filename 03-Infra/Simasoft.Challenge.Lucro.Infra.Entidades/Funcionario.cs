using System;

namespace Simasoft.Challenge.Lucro.Infra.Entidades
{
    public class Funcionario: IEntidade
    {
        public Funcionario(long? id, long? matricula, string nome, string area, string cargo, float salarioBruto, DateTime dataAdmissao)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Area = area;
            Cargo = cargo;
            SalarioBruto = salarioBruto;
            DataAdmissao = dataAdmissao;
        }

        public Funcionario(long? matricula, string nome, string area, string cargo, float salarioBruto, DateTime dataAdmissao)
        {            
            Matricula = matricula;
            Nome = nome;
            Area = area;
            Cargo = cargo;
            SalarioBruto = salarioBruto;
            DataAdmissao = dataAdmissao;
        }
        public long? Id { get ; set; }
        public long? Matricula { get; private set; }        
        public string Nome { get; private set; }        
        public string Area { get; private set; }       
        public string Cargo { get; private set; }        
        public float SalarioBruto { get; private set; }        
        public DateTime DataAdmissao { get; private set; }
        public bool Estagiario { get; set; }        
    }
}