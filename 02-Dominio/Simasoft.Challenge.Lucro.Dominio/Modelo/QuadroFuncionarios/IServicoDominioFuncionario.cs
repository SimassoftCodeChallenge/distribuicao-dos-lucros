using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios
{
    public interface IServicoDominioFuncionario
    {
        long CadastrarFuncionario(Funcionario funcionario);
        IEnumerable<long> CadastrarFuncionarios(IEnumerable<Funcionario> funcionarios);
    }
}
