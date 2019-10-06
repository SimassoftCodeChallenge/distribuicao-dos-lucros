using DapperExtensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using dominio = Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using Simasoft.Challenge.Lucro.Infra.Config;
using System.IO;
using System.Linq;

namespace Teste.Simasoft.Challenge.Lucro.Repositorio.Funcionario
{
    [TestClass]
    public class RepositorioFuncionarioTeste
    {
        protected IRepositorioFuncionario _repositorio;

        [TestInitialize]
        public void Inicializar()
        {
            var config = ConfiguracaoInicial();
            var relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
            var connectionStrings = $"{config["DatabaseConnection"].Replace("..",relativePath)}";

            var service = new ServiceCollection();
            service.AdicionarInjecaoDependenciaRepositorio(connectionStrings);
            var serviceProvider = service.BuildServiceProvider();

            _repositorio = serviceProvider.GetService<IRepositorioFuncionario>();
        }

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

        [TestMethod()]
        public void InsereFuncionario()
        {
            var predicado = Predicates.Field<dominio.Funcionario>(func => func.Matricula, Operator.Eq, 7239);
            dominio.Funcionario dorthyLee = new dominio.Funcionario(7239, "Dorthy Lee", "Financeiro", "Estagiário", 1491.45f,new System.DateTime(2015,03,16));
            _repositorio.Inserir(dorthyLee);
            dominio.Funcionario dorthyLeePersistida = _repositorio.Listar(predicado);
            Assert.IsTrue(dorthyLeePersistida.Matricula.HasValue && dorthyLeePersistida.Matricula.Value == 7239);
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
