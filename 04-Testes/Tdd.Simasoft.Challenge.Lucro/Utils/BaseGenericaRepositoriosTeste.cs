using DapperExtensions;
using DapperExtensions.Mapper;
using DapperExtensions.Sql;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Reflection;
using System.Text;
using Tdd.Simasoft.Challenge.Lucro.Tdd.Persistencia.Mappers;
using Tdd.Simasoft.Challenge.Lucro.Tdd.Utils;

namespace Tdd.Simasoft.Challenge.Lucro.Utils
{
    [TestClass]
    public class BaseGenericaRepositoriosTeste
    {
        protected IDbConnection dbconnection;
        protected readonly IDbTransaction dbTransaction;        
        protected ISqlGenerator sqlGenerator;

        
    }
}
