using System;
using System.Collections.Generic;
using System.Text;
using local = Tdd.Simasoft.Challenge.Lucro.Tdd.Persistencia.Entidades;

namespace Tdd.Simasoft.Challenge.Lucro.Tdd.Persistencia.SQLite.Repositorio
{
    public class RepositorioFuncionario : RepositorioSQLiteBase<local.Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(string connectionStrings) : base(connectionStrings)
        {
        }
    }
}
