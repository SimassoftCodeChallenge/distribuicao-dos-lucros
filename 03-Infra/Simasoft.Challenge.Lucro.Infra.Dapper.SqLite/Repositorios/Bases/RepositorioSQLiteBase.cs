using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Simasoft.Challenge.Lucro.Infra.DapperExtensionsCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using Simasoft.Challenge.Lucro.Infra.Sqlite.Mapeamentos;
using Simasoft.Challenge.Lucro.Infra.Repositorios.Bases;

namespace Simasoft.Challenge.Lucro.Infra.Dapper.Sqlite.Repositorios.Bases
{
    public abstract class RepositorioSQLiteBase<T> : RepositorioBase<T> where T: class
    {
        protected IDbConnection dbconnection;
        protected readonly IDbTransaction dbTransaction;
        protected ISqlGenerator sqlGenerator;

        public RepositorioSQLiteBase(string connectionStrings)
        {
            RepositorioConnectionFactory(connectionStrings);
        }
        public override IEnumerable<T> ListarTodos()
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                return Db.GetList<T>();
            }
        }

        public override IEnumerable<T> ListarPor(object filtro){
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                return Db.GetList<T>(filtro);
            }            
        }
        public override long? Inserir(T obj)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                return Db.Insert(obj);
            }
        }
        public override void Inserir(IEnumerable<T> obj)
        {
            if (obj != null && obj.Count() > 0)
            {
                foreach (var item in obj)
                {
                    Inserir(item);
                }
            }           
        }

        public override void Inserir(T[] obj)
        {
            if (obj != null && obj.Count() > 0)
            {
                foreach (var item in obj)
                {
                    Inserir(item);
                }
            }      
        }
        public override void Atualizar(T obj)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                Db.Update(obj);
            }
        }       

        public override bool Apagar(T obj)
        {
            bool resultado = false;
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                resultado = Db.Delete(obj);
            }
            return resultado;
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
    }
}
