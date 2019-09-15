using Simasoft.Challenge.Lucro.Dominio.Comum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios
{
    public class Colaborador: EntidadeBase
    {        
        public long? Matricula { get; private set; }              
        public string Nome { get; private set; }                
        public string Area { get; private set; }
        public string Cargo { get; private set; }
        public float SalarioBruto { get; private set; }
        public DateTime DataAdmissao { get; private set; }
        public bool EhEstagiario { get => ValidaCargoDeEstagiario(Cargo); }               

        public Colaborador(long? _matricula, string _nome, string _area, string _cargo, float _salarioBruto, DateTime _dataAdmissao)
        {
            Matricula = _matricula;
            Nome = _nome;
            Area = _area;
            Cargo = _cargo;
            SalarioBruto = _salarioBruto;
            DataAdmissao = _dataAdmissao;
        }

        private bool ValidaCargoDeEstagiario(string cargo)
        {
            return cargo.ToLower() == "estagiário" || cargo.ToLower() == "estagiario" ? true : false;
        }
    }
}
