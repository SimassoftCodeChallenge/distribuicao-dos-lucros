using System.Collections.Generic;
using System.Linq;
using Simasoft.Challenge.Lucro.Aplicacao.Contratos;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.DistribuicaoLucro;
using Simasoft.Challenge.Lucro.Dominio.Contratos.Servicos;
using Simasoft.Challenge.Lucro.Dominio.Modelo.DistribuicaoLucros;
using Simasoft.Challenge.Lucro.Dominio.Modelo.QuadroFuncionarios;

namespace Simasoft.Challenge.Lucro.Aplicacao.Servicos
{
    public class ServicoAplicacaoDistribuicaoLucros : IAplicacaoDistribuicaoLucros
    {
        private readonly IServicoDominioFuncionario _servicoFuncionario;
        private readonly IServicoDominioDistribuicaoLucros _servicoDistribuicaoLucros;

        public ServicoAplicacaoDistribuicaoLucros(IServicoDominioFuncionario servicoFuncionario, IServicoDominioDistribuicaoLucros servicoDistribuicaoLucros)
        {
            _servicoFuncionario = servicoFuncionario;
            _servicoDistribuicaoLucros = servicoDistribuicaoLucros;
        }

        public ResultadoDistribuicaoLucrosDto ExecutaDistribuicao(float valorDisponibilizado,float salarioMinimoNacional)
        {
            IEnumerable<Funcionario> funcionarios = _servicoFuncionario.ListarTodos().Result;
            List<Funcionario> funcionarioList = funcionarios.ToList();
            DistribuicaoLucro resultadoEntidade = _servicoDistribuicaoLucros.ExecutaDistribuicaoDosLucros(funcionarioList,valorDisponibilizado,salarioMinimoNacional);

            return HidrataDto(resultadoEntidade);        
        }

        private ResultadoDistribuicaoLucrosDto HidrataDto(DistribuicaoLucro entidade)
        {
            ResultadoDistribuicaoLucrosDto dto = new ResultadoDistribuicaoLucrosDto(){
                TotalDisponibilizado = entidade.TotalDisponibilizado,
                TotalDistribuido = entidade.TotalDistribuido,
                TotalFuncionarios = entidade.TotalDeFuncionarios,
                SaldoTotalDisponibilizado = entidade.SaldoTotalDisponibilizado,                
            };

            List<ParticipacaoDto> participantesDto = new List<ParticipacaoDto>();
            foreach(var linha in entidade.Participantes){
                participantesDto.Add(new ParticipacaoDto(){
                    Matricula = linha.Matricula,
                    Nome = linha.Nome,
                    ValorParticipacao = linha.ValorDeParticipacaoRecebido()
                });
            }

            return dto;
        }
    }
}