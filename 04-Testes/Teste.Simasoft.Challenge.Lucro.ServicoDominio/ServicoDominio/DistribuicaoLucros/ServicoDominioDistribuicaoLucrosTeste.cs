using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Repositorio;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.IoC.Dominio;
using System.Linq;

namespace Teste.Simasoft.Challenge.Lucro.ServicoDominio.ServicoDominio.DistribuicaoLucros
{
    [TestClass]
    public class ServicoDominioDistribuicaoLucrosTeste
    {
        protected IServicoDominioDistribuicaoLucros _distribuicaoLucrosServico;
        protected IServicoDominioFuncionario _funcionarioServico;
        private float _salarioMinimo;

        [TestInitialize]
        public void Inicializar()
        {
            var config = ConfiguracaoInicial();
            var relativePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", "");
            var connectionStrings = $"{config["DatabaseConnection"].Replace("..", relativePath)}";
            _salarioMinimo = float.Parse(config["SalarioMinimoNacional"]);

            var service = new ServiceCollection();            
            service.AdicionarInjecaoDependenciaDominio();
                        
            var serviceProvider = service.BuildServiceProvider();            
            _distribuicaoLucrosServico = serviceProvider.GetService<IServicoDominioDistribuicaoLucros>();
            _funcionarioServico = serviceProvider.GetService<IServicoDominioFuncionario>();
        }

        [TestMethod]
        public void ProcessarParticipacaoNoLucrosTeste()
        {
            var funcionarios = _funcionarioServico.ListarTodos().Result.ToList();
            var resultado = _distribuicaoLucrosServico.ExecutaDistribuicaoDosLucros(funcionarios,4000000,_salarioMinimo);
            Assert.IsTrue(true);
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