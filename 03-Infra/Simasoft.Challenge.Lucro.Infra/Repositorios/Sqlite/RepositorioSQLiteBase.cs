using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Simasoft.Challenge.Lucro.Dominio.Comum;
using Simasoft.Challenge.Lucro.Infra.Comum;
using Simasoft.Challenge.Lucro.Infra.DapperExtensionsCore;
using Simasoft.Challenge.Lucro.Infra.Funcionario;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Simasoft.Challenge.Lucro.Infra.Repositorios.Sqlite
{
    public abstract class RepositorioSQLiteBase<T> : IRepositorioBase<T> where T: class
    {
        protected IDbConnection dbconnection;
        protected readonly IDbTransaction dbTransaction;
        protected ISqlGenerator sqlGenerator;

        public RepositorioSQLiteBase(string connectionStrings)
        {
            SQLiteConnectionFactory(connectionStrings);
        }

        public T Listar(object predicado)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                return Db.Get<T>(predicado);
            }
        }

        public IEnumerable<T> ListarTodos()
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                return Db.GetList<T>();
            }
        }

        public IEnumerable<T> PegaLista(object predicado)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                return Db.GetList<T>(predicado);
            }
        }

        public void Inserir(T obj)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                Db.Insert(obj);
            }
        }

        public void Inserir(IEnumerable<T> obj)
        {
            if (obj != null && obj.Count() > 1)
            {
                foreach (var item in obj)
                {
                    Inserir(item);
                }
            }
            else
            {
                if (obj != null && obj.Count() == 1)
                    Inserir(obj.SingleOrDefault());
            }
        }

        public long InserirRetornandoId(T obj)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                return Db.Insert(obj);
            }
        }

        public IEnumerable<long> InserirRetornandoId(IEnumerable<T> obj)
        {
            List<long> ids = new List<long>();

            foreach (var item in obj)
            {
                var id = InserirRetornandoId(item);
                ids.Add(id);
            }

            return ids;
        }

        public void Atualizar(T obj)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                Db.Update(obj);
            }
        }

        public void Apagar(object predicado)
        {
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                Db.Delete(predicado);
            }
        }

        public bool Apagar(T obj)
        {
            bool resultado = false;
            using (IDatabase Db = new Database(dbconnection, sqlGenerator))
            {
                resultado = Db.Delete(obj);
            }
            return resultado;
        }

        private void SQLiteConnectionFactory(string connectionString)
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
