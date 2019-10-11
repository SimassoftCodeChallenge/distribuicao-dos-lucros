using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Simasoft.Challenge.Lucro.Api.Models;
using Simasoft.Challenge.Lucro.Aplicacao.Contratos;
using Simasoft.Challenge.Lucro.Aplicacao.Dto.Funcionario;

namespace Simasoft.Challenge.Lucro.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FuncionarioController: BaseController
    {
        private readonly  IAplicacaoFuncionario _appFuncionario;

        public FuncionarioController(IAplicacaoFuncionario appFuncionario)
        {
            _appFuncionario = appFuncionario;
        }

        [HttpPost]
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

        public FuncionarioDto[] HidrataDto(FuncionarioModel[] funcionarios){
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