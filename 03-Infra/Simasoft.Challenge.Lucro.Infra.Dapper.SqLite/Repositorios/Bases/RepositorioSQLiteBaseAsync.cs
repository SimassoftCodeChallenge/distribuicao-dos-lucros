using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios.Comum;
using Simasoft.Challenge.Lucro.Infra.DapperExtensionsCore;
using Simasoft.Challenge.Lucro.Infra.Repositorios.Bases;
using Simasoft.Challenge.Lucro.Infra.Sqlite.Mapeamentos;

namespace Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios.Bases
{
    public abstract class RepositorioSQLiteBaseAsync<T> : RepositorioBaseAsync<T> where T : class
    {
        protected IDbConnection dbconnection;
        protected readonly IDbTransaction dbTransaction;
        protected ISqlGenerator sqlGenerator;
        protected RepositorioSQLiteBaseAsync(string connectionStrings)
        {
            RepositorioConnectionFactory(connectionStrings);
        }        
        public override void RepositorioConnectionFactory(string connectionString)
        {
            var sqlDialectAsync = DapperAsyncExtensions.SqlDialect = new SqliteDialect();
            dbconnection = new SQLiteConnection(connectionString,true);
            var config = new DapperExtensionsConfiguration(
                            typeof(AutoClassMapper<>),
                            new List<Assembly>() { typeof(FuncionarioMap).Assembly },
                            sqlDialectAsync
                        );

            sqlGenerator = new SqlGeneratorImpl(config);            
        }        
        public override async Task<bool> ApagarAsync(T obj)
        {      
            bool resultado = false;      
            using (IDatabaseAsync db = new DatabaseAsync(dbconnection, sqlGenerator))
            {
                resultado = await db.DeleteAsync(obj);
            }
            return resultado;
        }

        public override async Task AtualizarAsync(T obj)
        {
            using (IDatabaseAsync Db = new DatabaseAsync(dbconnection, sqlGenerator))
            {
                await Db.UpdateAsync(obj);
            }
        }

        public override async Task<long> InserirAsync(T obj)
        {
            using (IDatabaseAsync Db = new DatabaseAsync(dbconnection, sqlGenerator))
            {
                return await Db.InsertAsync(obj);
            }
        }
        public override async Task InserirAsync(IEnumerable<T> obj)
        {
            if (obj != null && obj.Count() > 0)
            {
                foreach (var item in obj)
                {
                    await InserirAsync(item);
                }
            }
        }

        public override async Task InserirAsync(T[] obj)
        {
            if (obj != null && obj.Count() > 0)
            {
                foreach (var item in obj)
                {
                    await InserirAsync(item);
                }
            }
        }

        public override async Task<IEnumerable<T>> ListarPorAsync(object filtro){
            using (IDatabaseAsync Db = new DatabaseAsync(dbconnection, sqlGenerator))
            {
                return await Db.GetListAsync<T>(filtro);
            }            
        }

        public override async Task<IEnumerable<T>> ListarTodosAsync()
        {
            using (IDatabaseAsync Db = new DatabaseAsync(dbconnection, sqlGenerator))
            {
                return await Db.GetListAsync<T>();
            }
        }
    }
}