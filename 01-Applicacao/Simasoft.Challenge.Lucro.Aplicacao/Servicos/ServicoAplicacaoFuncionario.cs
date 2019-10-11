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
            var entidades = await _servicoFuncionario.ListarTodos();
            HidrataDto(entidades.ToArray());
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
    }
}