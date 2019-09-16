using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using Simasoft.Challenge.Lucro.Infra.Repositorios.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;
using dominio = Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;

namespace Simasoft.Challenge.Lucro.Infra.Funcionario
{
    public class RepositorioFuncionario : RepositorioSQLiteBase<dominio.Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(string connectionStrings) : base(connectionStrings)
        {
        }
    }
}
