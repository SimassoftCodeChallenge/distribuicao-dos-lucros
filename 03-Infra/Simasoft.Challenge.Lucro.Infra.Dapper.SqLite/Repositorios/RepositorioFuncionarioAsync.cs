using Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios.Bases;
using infra = Simasoft.Challenge.Lucro.Infra.Entidades;

namespace Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios
{
    public class RepositorioFuncionarioAsync : RepositorioSQLiteBaseAsync<infra.Funcionario>
    {
        public RepositorioFuncionarioAsync(string connectionStrings) : base(connectionStrings)
        {
        }
    }
}