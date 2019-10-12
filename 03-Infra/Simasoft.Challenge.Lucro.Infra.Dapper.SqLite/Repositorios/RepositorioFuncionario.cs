using System.Linq;
using DapperExtensions;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios.Bases;
using Simasoft.Challenge.Lucro.Infra.Entidades;

namespace Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios
{
    public class RepositorioFuncionario : RepositorioSQLiteBase<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(string connectionStrings) : base(connectionStrings)
        {
        }

        public Funcionario ListarPor(long id)
        {
            var predicado = Predicates.Field<Funcionario>(func => func.Id, Operator.Eq, id);
            var resultado = ListarPor(predicado);
            
            return (resultado != null && resultado.Count() == 1) ? resultado.FirstOrDefault() : null;
        }

        public Funcionario ListarPor(string matricula)
        {
            var predicado = Predicates.Field<Funcionario>(func => func.Matricula, Operator.Eq, matricula);
            var resultado = ListarPor(predicado);
            
            return (resultado != null && resultado.Count() == 1) ? resultado.FirstOrDefault() : null;
        }       
    }
}
