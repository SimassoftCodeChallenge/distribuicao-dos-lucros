using System.Collections.Generic;
using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;

namespace Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos
{
    public interface IServicoDominioFuncionario
    {
         Task CadastrarFuncionario(Funcionario funcionario);
         Task CadastrarFuncionarios(Funcionario[] funcionarios);
         Task<IEnumerable<Funcionario>> ListarTodos();
    }
}