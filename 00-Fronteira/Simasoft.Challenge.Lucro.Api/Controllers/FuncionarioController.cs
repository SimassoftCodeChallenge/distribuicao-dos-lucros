using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simasoft.Challenge.Lucro.Api.Models;
using Simasoft.Challenge.Lucro.Aplicacao.Contratos;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.Funcionario;

namespace Simasoft.Challenge.Lucro.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionarioController: BaseController
    {
        private readonly  IAplicacaoFuncionario _appFuncionario;

        public FuncionarioController(IAplicacaoFuncionario appFuncionario)
        {
            _appFuncionario = appFuncionario;
        }

        /// <summary>
        /// Cadastra uma Lista de Funcionários
        /// </summary>
        /// <remarks>
        /// Request de Exemplo:
        /// 
        ///     POST /funcionario
        ///     {
        ///         [
        ///            {
        ///              "matricula": "0009968",
        ///              "nome": "Victor Wilson",
        ///              "area": "Diretoria",
        ///              "cargo": "Diretor Financeiro",
        ///              "salariobruto": 12696.20,
        ///              "dataadmissao": "2012-01-05"
        ///             }
        ///          ]
        ///     }
        /// </remarks>
        /// <param name="funcionarios">Lista de Funcionários para Cadastro</param>  
        /// <response code="200">O cadastro foi executado com sucesso.</response>      
        /// <response code="500">O cadastro não foi concluído por ter retornado algum erro.</response>      
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CadastrarFuncionarios([FromBody]FuncionarioModel[] funcionarios)
        {            
            try
            {
                var dtos = HidrataDto(funcionarios);
                await _appFuncionario.CadastrarFuncionarios(dtos);                
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        private FuncionarioDto[] HidrataDto(FuncionarioModel[] funcionarios){
            List<FuncionarioDto> funcionariosDto = new List<FuncionarioDto>();

            foreach(var linha in funcionarios){
                funcionariosDto.Add(
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

            return funcionariosDto.ToArray();
        }
    }
}