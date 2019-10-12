using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simasoft.Challenge.Lucro.Api.Models;
using Simasoft.Challenge.Lucro.Aplicacao.Contratos;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.DistribuicaoLucro;
using Simasoft.Challenge.Lucro.Infra.CrossCutting.Config;

namespace Simasoft.Challenge.Lucro.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DistribuicaoLucroController: BaseController
    {
        private readonly IAplicacaoDistribuicaoLucros _appDistribuicao;
        private readonly ConfiguracaoAplicacao _config;

        public DistribuicaoLucroController(IAplicacaoDistribuicaoLucros appDistribuicao, ConfiguracaoAplicacao config)
        {
            _appDistribuicao = appDistribuicao;
            _config = config;
        }

        /// <summary>
        /// Processa o Cálculo da Distribuição dos Lucros para os Funcionários
        /// </summary>
        /// Request de Exemplo:
        /// 
        ///     GET /distribuicaolucro/124500
        ///         
        /// <param name="valorDisponibilizado">Valor disponibilizado para Distribuição</param>
        /// <returns>A informação de Processamento.</returns>
        /// <response code="200">O cadastro foi executado com sucesso.</response>      
        /// <response code="500">O cadastro não foi concluído por ter retornado algum erro.</response>      
        [HttpGet("{valorDisponibilizado}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> ProcessaDistribuicaoDosLucros(decimal valorDisponibilizado)
        {
            try
            {
               var resultado = await Task.FromResult(_appDistribuicao.ExecutaDistribuicao(valorDisponibilizado,float.Parse(_config.SalarioMinimoNacional)));
               return Ok(HidrataModel(resultado));
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        private ResultadoDistribuicaoLucroModel HidrataModel(ResultadoDistribuicaoLucrosDto dto)
        {
            ResultadoDistribuicaoLucroModel model = new ResultadoDistribuicaoLucroModel(){
                TotalDisponibilizado = dto.TotalDisponibilizado,
                TotalDistribuido = dto.TotalDistribuido,
                TotalFuncionarios = dto.TotalFuncionarios,
                SaldoTotalDisponibilizado = dto.SaldoTotalDisponibilizado               
            };

            List<ParticipacaoModel> participantesModel = new List<ParticipacaoModel>();
            foreach(var linha in dto.Participacoes){
                participantesModel.Add(new ParticipacaoModel(){
                    Matricula = linha.Matricula,
                    Nome = linha.Nome,
                    ValorParticipacao = linha.ValorParticipacao
                });
            }
            if(model.Participacoes != null){
                model.Participacoes.AddRange(participantesModel);
            }else{
                model.Participacoes = new List<ParticipacaoModel>();
                model.Participacoes.AddRange(participantesModel);
            }
            return model;
        }
    }
}