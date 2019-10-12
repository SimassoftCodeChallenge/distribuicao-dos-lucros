using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Repositorio;
using modelo = Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.IoC.Dominio;

namespace Teste.Simasoft.Challenge.Lucro.ServicoDominio.ServicoDominio.Funcionario
{
    [TestClass]
    public class ServicoDominioFuncionarioTeste
    {        
        protected IServicoDominioFuncionario _dominioServico;

        [TestInitialize]
        public void Inicializar()
        {
            var config = ConfiguracaoInicial();
            var relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
            var connectionStrings = $"{config["DatabaseConnection"].Replace("..", relativePath)}";

            var service = new ServiceCollection();            
            service.AdicionarInjecaoDependenciaDominio();
                        
            var serviceProvider = service.BuildServiceProvider();            
            _dominioServico = serviceProvider.GetService<IServicoDominioFuncionario>();
        }

        private static IConfiguration ConfiguracaoInicial()
        {
            return new ConfigurationBuilder()
             .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", ""))
             .AddJsonFile("appSettings.teste.json", optional: false, reloadOnChange: true)
             .Build();
        }

        [TestMethod()]
        public async Task CadastrarFuncionarios()
        {
            modelo.Funcionario[] funcionarios =  new modelo.Funcionario[] { 
                new modelo.Funcionario(0006877,"Cross Perkins","Relacionamento com o Cliente","Líder de Ouvidoria",3371.47f,new DateTime(2016,12,06)),
                new modelo.Funcionario(0008601,"Taylor Mccarthy","Relacionamento com o Cliente","Auxiliar de Ouvidoria",1800.16f,new DateTime(2017,03,31)),
                new modelo.Funcionario(0002105,"Dorthy Lee","Financeiro","Estagiário",1491.45f,new DateTime(2015,03,16)),
                new modelo.Funcionario(0000273,"Petersen Coleman","Financeiro","Estagiário",1426.13f,new DateTime(2016,09,20))
            };            
            await _dominioServico.CadastrarFuncionarios(funcionarios);
            Assert.IsTrue(true);
        }                    
    }   
}
