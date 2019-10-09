using System.Threading.Tasks;

using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using modelo = Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using entidade = Simasoft.Challenge.Lucro.Infra.Entidades;

namespace Simasoft.Challenge.Lucro.Dominio.Servicos.Funcionario
{
    public class ServicoDominioFuncionario: IServicoDominioFuncionario
    {
        private readonly IRepositorioFuncionarioAsync _repositorioFuncionario;

        public ServicoDominioFuncionario(IRepositorioFuncionarioAsync repositorioFuncionario)
        {
            _repositorioFuncionario = repositorioFuncionario;
        }

        public async Task CadastrarFuncionario(modelo.Funcionario funcionario)
        {
            throw new System.NotImplementedException();
        }

        public async Task CadastrarFuncionarios(modelo.Funcionario[] funcionarios)
        {
            throw new System.NotImplementedException();
        }
    }
}