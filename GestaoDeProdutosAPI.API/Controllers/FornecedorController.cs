using GestaoDeProdutosAPI.Aplicacao.DTOs;
using GestaoDeProdutosAPI.Aplicacao.Interfaces;
using GestaoDeProdutosAPI.Dominio.Constantes;
using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Dominio.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeFornecedorsAPI.API.Controllers
{
    [Route("api/fornecedor")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorAplicacao _fornecedorAplicacao;

        public FornecedorController(IFornecedorAplicacao FornecedorAplicacao)
        {
            _fornecedorAplicacao = FornecedorAplicacao;
        }

        [HttpGet]
        public async Task<ActionResult<List<FornecedorDto>>> BuscarTodosFornecedors()
        {
            try
            {
                List<FornecedorDto> retorno = await _fornecedorAplicacao.BuscarTodosAsync();
                return StatusCode(StatusCodes.Status200OK, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<FornecedorDto>> BuscarFornecedorPorCodigo(int codigo)
        {
            try
            {
                FornecedorDto retorno = await _fornecedorAplicacao.BuscarPorCodigoAsync(codigo);
                return StatusCode(StatusCodes.Status200OK, retorno);
            }
            catch (RegistroNaoEncontradoException e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorDto>> CadastrarFornecedor(CadastroFornecedorModel modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status409Conflict, Mensagens.PreencherCampos);
                }
                FornecedorDto retorno = await _fornecedorAplicacao.CadastrarAsync(modelo);
                return StatusCode(StatusCodes.Status201Created, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<FornecedorDto>> AtualizarFornecedor(AtualizaFornecedorModel modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status409Conflict, Mensagens.PreencherCampos);
                }
                FornecedorDto retorno = await _fornecedorAplicacao.AtualizarAsync(modelo);
                return StatusCode(StatusCodes.Status200OK, retorno);
            }
            catch (RegistroNaoEncontradoException e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> DeletarFornecedor(int codigo)
        {
            try
            {
                await _fornecedorAplicacao.DeletarAsync(codigo);
                return StatusCode(StatusCodes.Status200OK, Mensagens.ExcluidoComSucesso);
            }
            catch (RegistroNaoEncontradoException e)
            {
                return StatusCode(StatusCodes.Status204NoContent, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}