using System.Threading.Tasks;

using Simasoft.Challenge.Lucro.Dominio.Contratos.Repositorios;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using modelo = Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;
using entidade = Simasoft.Challenge.Lucro.Infra.Entidades;
using System.Collections.Generic;

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
            var entidade = HidratarEntidade(funcionario);
            await _repositorioFuncionario.InserirAsync(entidade);
        }

        public async Task CadastrarFuncionarios(modelo.Funcionario[] funcionarios)
        {   
            var entidade = HidratarEntidade(funcionarios);
            await _repositorioFuncionario.InserirAsync(entidade);
        }

        public async Task<IEnumerable<modelo.Funcionario>> ListarTodos()
        {            
            var listaEntidades = await _repositorioFuncionario.ListarTodosAsync();
            return HidrataModeloDominio(listaEntidades);
        }

        public entidade.Funcionario HidratarEntidade(modelo.Funcionario funcionario){
            entidade.Funcionario _entidade = new entidade.Funcionario(){
                Matricula = funcionario.Matricula,
                Nome = funcionario.Nome,
                Area = funcionario.Area,
                Cargo = funcionario.Cargo,
                DataAdmissao = funcionario.DataAdmissao,
                SalarioBruto = funcionario.SalarioBruto,
                Estagiario = funcionario.Estagiario
            };

            return _entidade;
        }

        public entidade.Funcionario[] HidratarEntidade(modelo.Funcionario[] funcionarios){
            List<entidade.Funcionario> entidadeFuncionarios = new List<entidade.Funcionario>();
            foreach(var linha in funcionarios){
                entidadeFuncionarios.Add(HidratarEntidade(linha));
            }
            return entidadeFuncionarios.ToArray();
        }

        public IEnumerable<modelo.Funcionario> HidrataModeloDominio(IEnumerable<entidade.Funcionario> funcionarios)
        {
            List<modelo.Funcionario> listaModelo = new List<modelo.Funcionario>();
            foreach(var linha in funcionarios)
            {
                listaModelo.Add(
                    new modelo.Funcionario(linha.Matricula,linha.Nome,linha.Area,linha.Cargo,linha.SalarioBruto,linha.DataAdmissao)
                );
            }

            return listaModelo;
        }
    }
}