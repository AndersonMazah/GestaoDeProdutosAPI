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

namespace GestaoDeProdutosAPI.API.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoAplicacao _produtoAplicacao;

        public ProdutoController(IProdutoAplicacao ProdutoAplicacao)
        {
            _produtoAplicacao = ProdutoAplicacao;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProdutoDto>>> BuscarTodosProdutos()
        {
            try
            {
                List<ProdutoDto> retorno = await _produtoAplicacao.BuscarTodosAsync();
                return StatusCode(StatusCodes.Status200OK, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<ProdutoDto>> BuscarProdutoPorCodigo(int codigo)
        {
            try
            {
                ProdutoDto retorno = await _produtoAplicacao.BuscarPorCodigoAsync(codigo);
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
        public async Task<ActionResult<ProdutoDto>> CadastrarProduto(CadastroProdutoModel modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status409Conflict, Mensagens.PreencherCampos);
                }
                ProdutoDto retorno = await _produtoAplicacao.CadastrarAsync(modelo);
                return StatusCode(StatusCodes.Status201Created, retorno);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoDto>> AtualizarProduto(AtualizaProdutoModel modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status409Conflict, Mensagens.PreencherCampos);
                }
                ProdutoDto retorno = await _produtoAplicacao.AtualizarAsync(modelo);
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
        public async Task<ActionResult> DeletarProduto(int codigo)
        {
            try
            {
                await _produtoAplicacao.DeletarAsync(codigo);
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