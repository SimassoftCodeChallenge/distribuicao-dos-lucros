using System.Linq;
using System.Threading.Tasks;
using DapperExtensions;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios.Bases;
using Simasoft.Challenge.Lucro.Infra.Entidades;

namespace Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios
{
    public class RepositorioFuncionarioAsync : RepositorioSQLiteBaseAsync<Funcionario>, IRepositorioFuncionarioAsync
    {
        public RepositorioFuncionarioAsync(string connectionStrings) : base(connectionStrings)
        {
        }

        public async Task<Funcionario> ListarPorAsync(long id)
        {
            var predicado = Predicates.Field<Funcionario>(func => func.Id, Operator.Eq, id);
            var resultado = await ListarPorAsync(predicado);
            
            return (resultado != null && resultado.Count() == 1) ? resultado.FirstOrDefault() : null;    
        }

        public async Task<Funcionario> ListarPorAsync(string matricula)
        {
            var predicado = Predicates.Field<Funcionario>(func => func.Matricula, Operator.Eq, matricula);
            var resultado = await ListarPorAsync(predicado);
            
            return (resultado != null && resultado.Count() == 1) ? resultado.FirstOrDefault() : null;
        }
    }
}