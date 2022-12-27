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

namespace GestaoDeFornecedorsAPI.Aplicacao.Services
{
    public class FornecedorAplicacao : IFornecedorAplicacao
    {
        private readonly IFornecedorRepositorio _fornecedorRepositorio;
        private readonly IMapper _mapper;

        public FornecedorAplicacao(IMapper mapper, IFornecedorRepositorio fornecedorReposiorio)
        {
            _mapper = mapper;
            _fornecedorRepositorio = fornecedorReposiorio;
        }

        public async Task<List<FornecedorDto>> BuscarTodosAsync()
        {
            List<Fornecedor> fornecedores = await _fornecedorRepositorio.ObterTodosAsync();
            return _mapper.Map<List<Fornecedor>, List<FornecedorDto>>(fornecedores);
        }

        public async Task<FornecedorDto> BuscarPorCodigoAsync(int codigo)
        {
            Fornecedor fornecedor = await _fornecedorRepositorio.ObterPorCodigoAsync(codigo);
            if (fornecedor is null)
            {
                throw new RegistroNaoEncontradoException("Fornecedor", Mensagens.RegistroNaoEncontrado);
            }
            return _mapper.Map<Fornecedor, FornecedorDto>(fornecedor);
        }

        public async Task<FornecedorDto> CadastrarAsync(CadastroFornecedorModel modelo)
        {
            Fornecedor fornecedor = new Fornecedor(modelo);
            await _fornecedorRepositorio.CadastrarAsync(fornecedor);
            return _mapper.Map<Fornecedor, FornecedorDto>(fornecedor);
        }

        public async Task<FornecedorDto> AtualizarAsync(AtualizaFornecedorModel modelo)
        {
            Fornecedor fornecedor = await _fornecedorRepositorio.ObterPorCodigoAsync(modelo.Codigo);
            if (fornecedor is null)
            {
                throw new RegistroNaoEncontradoException("Fornecedor", Mensagens.RegistroNaoEncontrado);
            }
            fornecedor.Atualizar(modelo);
            await _fornecedorRepositorio.AtualizarAsync(fornecedor);
            return _mapper.Map<Fornecedor, FornecedorDto>(fornecedor);
        }

        public async Task DeletarAsync(int codigo)
        {
            try
            {
                Fornecedor fornecedor = await _fornecedorRepositorio.ObterPorCodigoAsync(codigo);
                if (fornecedor is null)
                {
                    throw new RegistroNaoEncontradoException("Fornecedor", Mensagens.RegistroNaoEncontrado);
                }
                await _fornecedorRepositorio.DeletarAsync(fornecedor);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}