using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simasoft.Challenge.Lucro.Api.Models;
using Simasoft.Challenge.Lucro.Aplicacao.Contratos;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.DistribuicaoLucro;

namespace Simasoft.Challenge.Lucro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistribuicaoLucroController: BaseController
    {
        private readonly IAplicacaoDistribuicaoLucros _appDistribuicao;

        public DistribuicaoLucroController(IAplicacaoDistribuicaoLucros appDistribuicao)
        {
            _appDistribuicao = appDistribuicao;
        }

        [HttpGet]
        public async Task<IActionResult> ProcessaDistribuicaoDosLucros()
        {
            try
            {
               var resultado = await Task.FromResult(_appDistribuicao.ExecutaDistribuicao(0,998f));
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

            return model;
        }
    }
}