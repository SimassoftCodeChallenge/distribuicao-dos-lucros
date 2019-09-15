﻿using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Simasoft.Challenge.Lucro.Dominio.Comum;
using Simasoft.Challenge.Lucro.Infra.Colaborador;
using Simasoft.Challenge.Lucro.Infra.Comum;
using Simasoft.Challenge.Lucro.Infra.DapperExtensionsCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Threading.Tasks;

namespace Simasoft.Challenge.Lucro.Infra.Repositorios.Sqlite
{
    public abstract class RepositorioSQLiteBase<T> : IRepositorioBase<T> where T: EntidadeBase
    {
        protected IDbConnection dbconnection;
        protected readonly IDbTransaction dbTransaction;
        protected ISqlGenerator sqlGenerator;

        public RepositorioSQLiteBase(string connectionStrings)
        {
            SQLiteConnectionFactory(connectionStrings);
        }

        public async Task<T> Listar(object predicado)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> PegaLista(object predicate)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(T obj)
        {
            throw new NotImplementedException();
        }

        public Task Inserir(IEnumerable<T> obj)
        {
            throw new NotImplementedException();
        }

        public Task<long> InserirRetornandoId(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<long>> InserirRetornandoId(IEnumerable<T> obj)
        {
            throw new NotImplementedException();
        }

        public Task Atualizar(T obj)
        {
            throw new NotImplementedException();
        }

        public Task Apagar(object predicado)
        {
            throw new NotImplementedException();
        }

        private void SQLiteConnectionFactory(string connectionString)
        {
            var sqlDialectAsync = DapperAsyncExtensions.SqlDialect = new SqliteDialect();
            dbconnection = new SQLiteConnection(connectionString);
            var config = new DapperExtensionsConfiguration(
                            typeof(AutoClassMapper<>),
                            new List<Assembly>() { typeof(ColaboradorMap).Assembly },
                            sqlDialectAsync
                        );

            sqlGenerator = new SqlGeneratorImpl(config);
            
        }

    }
}
