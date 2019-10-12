using System;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios
{
    public class Funcionario
    {        
        public long Id { get; set; }
        public long? Matricula { get; private set; }              
        public string Nome { get; private set; }                
        public string Area { get; private set; }
        public string Cargo { get; private set; }
        public float SalarioBruto { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public bool Estagiario { get => ValidaCargoDeEstagiario(Cargo); }                      

        public Funcionario(long? _matricula, string _nome, string _area, string _cargo, float _salarioBruto, DateTime _dataAdmissao)
        {
            Matricula = _matricula;
            Nome = _nome;
            Area = _area;
            Cargo = _cargo;
            SalarioBruto = _salarioBruto;
            DataAdmissao = _dataAdmissao;            
        }

        public Funcionario(long matricula, string nome, string area, string cargo, decimal salariobruto, string dataadmissao, long estagiario)
        {
            Matricula = matricula;
            Nome = nome;
            Area = area;
            Cargo = cargo;
            SalarioBruto = float.Parse(salariobruto.ToString());
            DataAdmissao = DateTime.Parse(dataadmissao);
        }

        public Funcionario(Int64 id, Int64 matricula, String nome, String area, String cargo, Decimal salariobruto, String dataadmissao, Int64 estagiario)
        {
            Id = id;
            Matricula = matricula;
            Nome = nome;
            Area = area;
            Cargo = cargo;
            SalarioBruto = float.Parse(salariobruto.ToString());
            DataAdmissao = DateTime.Parse(dataadmissao);            
        }

        private bool ValidaCargoDeEstagiario(string cargo)
        {
            return cargo.ToLower() == "estagiário" || cargo.ToLower() == "estagiario" ? true : false;
        }
    }
}
