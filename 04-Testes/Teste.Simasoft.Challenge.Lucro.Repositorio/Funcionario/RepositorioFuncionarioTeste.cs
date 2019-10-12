using DapperExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using System.Data.SQLite;
using Dapper;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Repositorio;
using entidade = Simasoft.Challenge.Lucro.Infra.Entidades;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Config;
using System.Collections.Generic;

namespace Teste.Simasoft.Challenge.Lucro.Repositorio.Funcionario
{
    [TestClass]
    public class RepositorioFuncionarioTeste
    {
        protected IRepositorioFuncionario _repositorio;
        protected string _connectionStrings;
        protected const string DMLAPAGATUDO = "DELETE FROM funcionario";
        protected const string DMLCONTARLINHAS = "SELECT COUNT(*) FROM funcionario";
        private static string _sessao = "Sqlite";
        private static ConfiguracaoAplicacao _configClient; 

        [TestInitialize]
        public void Inicializar()
        {
            var config = ConfiguracaoInicial();
            //var relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
            //_connectionStrings = $"{config["DatabaseConnection"].Replace("..",relativePath)}";
            var appconfig = GetConfigObject();

            var service = new ServiceCollection();
            service.AdicionarInjecaoDependenciaRepositorio(appconfig);
            var serviceProvider = service.BuildServiceProvider();

            _repositorio = serviceProvider.GetService<IRepositorioFuncionario>();            
        }
        private void LimparBase()
        {
            if(ContarLinhas() > 0)
            {
                using(SQLiteConnection conexao = new SQLiteConnection(_connectionStrings))
                {                
                    conexao.Query(DMLAPAGATUDO);                    
                }
            }            
        }        

        private int ContarLinhas()
        {
            int total = 0;
            using(SQLiteConnection conexao = new SQLiteConnection(_connectionStrings))
            {
              total = conexao.QueryFirstOrDefault<int>(DMLCONTARLINHAS);                    
            }
            return total;
        }        

        private static ConfiguracaoAplicacao PopulaObjeto()
        {
           _configClient = new ConfiguracaoAplicacao();
            var configClientType = _configClient.GetType();            
            var session = ConfiguracaoInicial().AsEnumerable();                        
            var arcabouco = session.ToDictionary(x => x.Key,x => x.Value)
                .Where(x => x.Key.Contains(_sessao + ":") && x.Value != null)
                .Select(t => new KeyValuePair<string,string>(t.Key.Replace(_sessao + ":",""),t.Value));
            
            arcabouco.ToList().ForEach(x => {
                configClientType
                    .GetProperty(x.Key)
                    .SetValue(_configClient, x.Value, null);
            });
            return _configClient;
        }

        public static ConfiguracaoAplicacao GetConfigObject() => PopulaObjeto();
        public static ConfiguracaoAplicacao GetConfiguracaoClient() => _configClient;

        [TestMethod()]
        public void Integracao()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void ListarTudo()
        {
            var resultado = _repositorio.ListarTodos();
            Assert.IsTrue(resultado.Count() > 0);
        }

        [TestMethod]
        public void ListarPorMatricula()
        {
            int matricula = 7239;
            var predicado = Predicates.Field<entidade.Funcionario>(func => func.Matricula, Operator.Eq, matricula);
            var resultado = _repositorio.ListarPor(matricula);
            Assert.IsTrue(resultado != null && resultado.Matricula.HasValue);
        }

        [TestMethod()]
        public void InsereFuncionario()
        {
            LimparBase();
            var predicado = Predicates.Field<entidade.Funcionario>(func => func.Matricula, Operator.Eq, 7239);
            entidade.Funcionario dorthyLee = new entidade.Funcionario(7239, "Dorthy Lee", "Financeiro", "Estagiário", 1491.45f,new System.DateTime(2015,03,16));
            _repositorio.Inserir(dorthyLee);
            var dorthyLeePersistida = _repositorio.ListarPor(dorthyLee.Matricula.Value);
            Assert.IsTrue(dorthyLeePersistida != null && dorthyLeePersistida.Matricula.HasValue);
        }
       
        private static IConfiguration ConfiguracaoInicial()
        {
            return new ConfigurationBuilder()
             .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", ""))
             .AddJsonFile("appSettings.teste.json", optional: false, reloadOnChange: true)
             .Build();
        }
    }
}
