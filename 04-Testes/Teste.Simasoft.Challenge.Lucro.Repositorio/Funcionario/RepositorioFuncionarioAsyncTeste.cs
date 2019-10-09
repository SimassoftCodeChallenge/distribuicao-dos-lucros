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
using System.Threading.Tasks;
using System;

namespace Teste.Simasoft.Challenge.Lucro.Repositorio.Funcionario
{
    [TestClass]
    public class RepositorioFuncionarioAsyncTeste
    {
        protected IRepositorioFuncionarioAsync _repositorio;
        protected string _connectionStrings;
        protected const string DMLAPAGATUDO = "DELETE FROM funcionario";
        protected const string DMLCONTARLINHAS = "SELECT COUNT(*) FROM funcionario";
        
        [TestInitialize]
        public void Inicializar()
        {
            var config = ConfiguracaoInicial();
            var relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
            _connectionStrings = $"{config["DatabaseConnection"].Replace("..",relativePath)}";

            var service = new ServiceCollection();
            service.AdicionarInjecaoDependenciaRepositorio(_connectionStrings);
            var serviceProvider = service.BuildServiceProvider();

            _repositorio = serviceProvider.GetService<IRepositorioFuncionarioAsync>();            
        }
        
        private static IConfiguration ConfiguracaoInicial()
        {
            return new ConfigurationBuilder()
             .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", ""))
             .AddJsonFile("appSettings.teste.json", optional: false, reloadOnChange: true)
             .Build();
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

        [TestMethod]
        public async Task CadastrarFuncionarioTeste()
        {
            var gabrielSimas = new entidade.Funcionario(45214,"Luís Gabriel Nascimento Simas","TI","Analista de Sistemas",20000,new DateTime(2019,10,09));                
            try{
                long? resultado = await _repositorio.InserirAsync(gabrielSimas);
                Assert.IsTrue(resultado > 0);
            }catch(Exception ex)
            {
                Assert.Fail("Erro ao Persistir Funcionário: " + ex.Message);
            }
            
        }

        public async Task CadastrarFuncionariosTeste() 
        {
            
        }
    }
}