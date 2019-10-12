using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simasoft.Challenge.Lucro.Aplicacao.Contratos;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.Funcionario;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;

namespace Simasoft.Challenge.Lucro.Aplicacao.Servicos
{
    public class ServicoAplicacaoFuncionario : IAplicacaoFuncionario
    {
        private readonly IServicoDominioFuncionario _servicoFuncionario;

        public ServicoAplicacaoFuncionario(IServicoDominioFuncionario servicoFuncionario)
        {
            _servicoFuncionario = servicoFuncionario;
        }

        public async Task CadastrarFuncionarios(FuncionarioDto[] funcionarios)
        {
            var modelos = HidrataModelo(funcionarios);
            await _servicoFuncionario.CadastrarFuncionarios(modelos);
        }

        public async Task<IEnumerable<FuncionarioDto>> ListarTodosOsFuncionarios()
        {
            var entidades = await _servicoFuncionario.ListarTodos();
            return HidrataDto(entidades.ToArray());
        }

        private FuncionarioDto[] HidrataDto(Funcionario[] entidades){
            List<FuncionarioDto> funcionarios = new List<FuncionarioDto>();
            foreach(var linha in entidades)
            {
                funcionarios.Add(
                    new FuncionarioDto(){
                        Matricula = linha.Matricula,
                        Nome = linha.Nome,
                        Area = linha.Area,
                        Cargo = linha.Cargo,
                        DataAdmissao = linha.DataAdmissao,
                        SalarioBruto = linha.SalarioBruto                        
                    }
                );
            }
            
            return funcionarios.ToArray();
        }

        private Funcionario[] HidrataModelo(FuncionarioDto[] dtos){
            List<Funcionario> funcionarios = new List<Funcionario>();
            foreach(var linha in dtos)
            {
                funcionarios.Add(
                    new Funcionario(linha.Matricula,linha.Nome,linha.Area,linha.Cargo,linha.SalarioBruto,linha.DataAdmissao)                        
                );
            }
            
            return funcionarios.ToArray();
        }
    }
}