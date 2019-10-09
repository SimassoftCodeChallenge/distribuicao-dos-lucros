using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios.Comum;
using Simasoft.Challenge.Lucro.Infra.Entidades;

namespace Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios
{
    public interface IRepositorioFuncionario: IRepositorioBase<Funcionario>
    {
         Funcionario ListarPor(long id);
         Funcionario ListarPor(string matricula);
    }
}