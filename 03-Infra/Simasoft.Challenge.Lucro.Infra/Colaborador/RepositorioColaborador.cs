using Simasoft.Challenge.Lucro.Infra.Repositorios.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Simasoft.Challenge.Lucro.Infra.Colaborador
{
    public class RepositorioColaborador : RepositorioSQLiteBase<Colaborador>
    {
        public RepositorioColaborador(string connectionStrings) : base(connectionStrings)
        {
        }
    }
}
