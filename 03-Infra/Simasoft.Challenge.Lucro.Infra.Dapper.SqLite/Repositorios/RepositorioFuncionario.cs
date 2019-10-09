using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios.Bases;
using infra = Simasoft.Challenge.Lucro.Infra.Entidades;
namespace Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios
{
    public class RepositorioFuncionario : RepositorioSQLiteBase<infra.Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(string connectionStrings) : base(connectionStrings)
        {
        }

        public infra.Funcionario ListarPor(long id)
        {
            throw new System.NotImplementedException();
        }

        public infra.Funcionario ListarPor(string matricula)
        {
            throw new System.NotImplementedException();
        }       
    }
}
