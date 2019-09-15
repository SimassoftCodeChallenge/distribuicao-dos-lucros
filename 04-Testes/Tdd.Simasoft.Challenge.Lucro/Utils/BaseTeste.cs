using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Tdd.Simasoft.Challenge.Lucro.Tdd.Utils
{
    [TestClass]
    public class BaseTeste
    {        
        protected IConfiguration config = null;
        protected float? salarioMinimoNacional = null;
        protected string connectionString = null;

        public string ConnectionDatabaseStrings
        {
            get => connectionString;
        }
        
        public static IConfiguration ConfiguracaoInicial()
        {
            return new ConfigurationBuilder()                
                 .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName.Replace("\\bin", ""))
                 .AddJsonFile("appSettings.teste.json", optional: false, reloadOnChange: true)
                 .Build();            
        }

        [TestInitialize]
        public void Inicializacao()
        {
            config = ConfiguracaoInicial();
            salarioMinimoNacional = float.Parse(config["SalarioMinimoNacional"]);
            connectionString = config["DatabaseConnection"];
        }
    }
}