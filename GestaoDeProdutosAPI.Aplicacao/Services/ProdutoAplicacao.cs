using AutoMapper;
using GestaoDeProdutosAPI.Aplicacao.DTOs;
using GestaoDeProdutosAPI.Aplicacao.Interfaces;
using GestaoDeProdutosAPI.Dominio.Constantes;
using GestaoDeProdutosAPI.Dominio.Entidades;
using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Dominio.Modelos;
using GestaoDeProdutosAPI.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoDeProdutosAPI.Aplicacao.Services
{
    public class ProdutoAplicacao : IProdutoAplicacao
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IMapper _mapper;

        public ProdutoAplicacao(IMapper mapper, IProdutoRepositorio produtoReposiorio)
        {
            _mapper = mapper;
            _produtoRepositorio = produtoReposiorio;
        }

        public async Task<Paginacao<ProdutoDto>> BuscarTodosAsync(int quantidade, int pagina)
        {
            List<Produto> produtos = await _produtoRepositorio.ObterTodosNoTrackingAsync(quantidade, pagina);
            List<ProdutoDto> produtosDto = _mapper.Map<List<Produto>, List<ProdutoDto>>(produtos);
            Paginacao<ProdutoDto> retorno = new Paginacao<ProdutoDto>(produtosDto.Count, produtosDto);
            return retorno;
        }

        public async Task<ProdutoDto> BuscarPorCodigoAsync(int codigo)
        {
            Produto produto = await _produtoRepositorio.ObterPorCodigoAsync(codigo);
            if (produto is null)
            {
                throw new RegistroNaoEncontradoException("Produto", Mensagens.RegistroNaoEncontrado);
            }
            return _mapper.Map<Produto, ProdutoDto>(produto);
        }

        public async Task<ProdutoDto> CadastrarAsync(CadastroProdutoModel modelo)
        {
            Produto produto = new Produto(modelo);
            await _produtoRepositorio.CadastrarAsync(produto);
            return _mapper.Map<Produto, ProdutoDto>(produto);
        }

        public async Task<ProdutoDto> AtualizarAsync(AtualizaProdutoModel modelo)
        {
            Produto produto = await _produtoRepositorio.ObterPorCodigoAsync(modelo.Codigo);
            if (produto is null)
            {
                throw new RegistroNaoEncontradoException("Produto", Mensagens.RegistroNaoEncontrado);
            }
            produto.Atualizar(modelo);
            await _produtoRepositorio.AtualizarAsync(produto);
            return _mapper.Map<Produto, ProdutoDto>(produto);
        }

        public async Task DeletarAsync(int codigo)
        {
            try
            {
                Produto produto = await _produtoRepositorio.ObterPorCodigoAsync(codigo);
                if (produto is null)
                {
                    throw new RegistroNaoEncontradoException("Produto", Mensagens.RegistroNaoEncontrado);
                }
                produto.MarcarComoDeletado();
                await _produtoRepositorio.AtualizarAsync(produto);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}