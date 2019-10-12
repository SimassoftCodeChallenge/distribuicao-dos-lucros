using System.Collections.Generic;
using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.Funcionario;

namespace Simasoft.Challenge.Lucro.Aplicacao.Contratos
{
    public interface IAplicacaoFuncionario
    {
         Task CadastrarFuncionarios(FuncionarioDto[] funcionarios);
         Task<IEnumerable<FuncionarioDto>> ListarTodosOsFuncionarios();
    }
}