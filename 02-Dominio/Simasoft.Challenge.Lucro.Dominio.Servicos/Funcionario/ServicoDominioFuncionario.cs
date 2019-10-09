using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;

namespace Simasoft.Challenge.Lucro.Dominio.Servicos.Funcionario
{
    public class ServicoDominioFuncionario: IServicoDominioFuncionario
    {
        private readonly IRepositorioFuncionario _repositorioFuncionario;

        public ServicoDominioFuncionario(IRepositorioFuncionario repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
        }
    }
}