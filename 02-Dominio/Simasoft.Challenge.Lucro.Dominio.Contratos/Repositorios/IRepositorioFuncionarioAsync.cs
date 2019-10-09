using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios.Comum;
using Simasoft.Challenge.Lucro.Infra.Entidades;

namespace Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios
{
    public interface IRepositorioFuncionarioAsync: IRepositorioBaseAsync<Funcionario>
    {
         Task<Funcionario> ListarPorAsync(long id);
         Task<Funcionario> ListarPorAsync(string matricula);
    }
}