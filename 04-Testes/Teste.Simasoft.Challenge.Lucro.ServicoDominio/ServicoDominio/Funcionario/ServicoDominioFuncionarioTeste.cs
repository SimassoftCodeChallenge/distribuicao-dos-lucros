using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Repositorio;

namespace Teste.Simasoft.Challenge.Lucro.ServicoDominio.ServicoDominio.Funcionario
{
    [TestClass]
    public class ServicoDominioFuncionarioTeste
    {
        protected IRepositorioFuncionario _repositorio;
        protected IServicoDominioFuncionario _dominioServico;

        [TestInitialize]
        public void Inicializar()
        {
            var config = ConfiguracaoInicial();
            var relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
            var connectionStrings = $"{config["DatabaseConnection"].Replace("..", relativePath)}";

            var service = new ServiceCollection();
            service.AdicionarInjecaoDependenciaRepositorio(connectionStrings);
            var serviceProvider = service.BuildServiceProvider();

            _repositorio = serviceProvider.GetService<IRepositorioFuncionario>();
            //_dominioServico = new ServicoDominioFuncionario(_repositorio);
        }

        private static IConfiguration ConfiguracaoInicial()
        {
            return new ConfigurationBuilder()
             .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", ""))
             .AddJsonFile("appSettings.teste.json", optional: false, reloadOnChange: true)
             .Build();
        }

        /*[TestMethod()]
        public void CadastrarFuncionario()
        {
            dominio.Funcionario _funcionario = new dominio.Funcionario(0004468, "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52f, new DateTime(2015, 01, 05));
           long id = _dominioServico.CadastrarFuncionario(_funcionario);
            Assert.IsTrue(id > 0);
        }

        [TestMethod()]
        public void CadastrarFuncionarios()
        {
            List<dominio.Funcionario> funcionarios = new List<dominio.Funcionario>();

            funcionarios.Add(new dominio.Funcionario(0004468, "Flossie Wilson", "Contabilidade", "Auxiliar de Contabilidade", 1396.52f, new DateTime(2015, 01, 05)));
            funcionarios.Add(new dominio.Funcionario(0008174, "Sherman Hodges", "Relacionamento com o Cliente", "Líder de Relacionamento", 3899.74f, new DateTime(2015, 06, 07)));

            var ids = _dominioServico.CadastrarFuncionarios(funcionarios.AsEnumerable());
            Assert.IsTrue(ids.Count() == 2);
        }*/
    }
}
