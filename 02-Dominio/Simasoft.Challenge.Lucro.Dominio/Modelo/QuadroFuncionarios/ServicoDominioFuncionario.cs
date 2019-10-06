using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios
{
    public class ServicoDominioFuncionario : IServicoDominioFuncionario
    {
        private readonly IRepositorioFuncionario _repositorio;

        public ServicoDominioFuncionario(IRepositorioFuncionario repositorio)
        {
            _repositorio = repositorio;
        }

        public long CadastrarFuncionario(Funcionario funcionario)
        {
            return _repositorio.InserirRetornandoId(funcionario);
        }

        public IEnumerable<long> CadastrarFuncionarios(IEnumerable<Funcionario> funcionarios)
        {
            return _repositorio.InserirRetornandoId(funcionarios);
        }
    }
}
