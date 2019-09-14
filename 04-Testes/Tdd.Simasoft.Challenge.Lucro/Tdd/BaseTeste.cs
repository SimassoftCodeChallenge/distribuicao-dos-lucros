using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tdd.Simasoft.Challenge.Lucro.Tdd
{
    [TestClass]
    public class BaseTeste
    {
        protected IConfiguration config = null;
        protected float? salarioMinimoNacional = null;

        public static IConfiguration ConfiguracaoInicial()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.teste.json")
                .Build();
                return config;
        }

        public void Inicializacao()
        {
            config = ConfiguracaoInicial();
            salarioMinimoNacional = float.Parse(config["SalarioMinimoNacional"]);
        }
    }
}