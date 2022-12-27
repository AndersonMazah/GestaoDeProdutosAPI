using GestaoDeProdutosAPI.Dominio.Enumeradores;
using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Dominio.Interface;
using System;

namespace GestaoDeProdutosAPI.Dominio.Entidades
{
    public class Produto : EntidadeBase, IEntidade
    {
        public string Descricao { get; private set; }

        public SituacaoProduto Situacao { get; private set; }

        public DateTime DataFabricacao { get; private set; }

        public DateTime DataValidade { get; private set; }

        public int FornecedorCodigo { get; private set; }

        protected Produto() { }

        public Produto(int codigo, string descricao, SituacaoProduto situacao, DateTime dataFabricacao, DateTime dataValidade, int fornecedorCodigo)
        {
            Codigo = codigo;
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            FornecedorCodigo = fornecedorCodigo;
            Validar();
        }

        public void Validar()
        {
            if (Codigo == 0)
            {
                throw new EntidadeInvalidaException("Produto", "Código inválido.");
            }
            if (string.IsNullOrWhiteSpace(Descricao))
            {
                throw new EntidadeInvalidaException("Produto", "Descrição não pode ser nulo.");
            }
            if (Situacao != SituacaoProduto.Ativo && Situacao != SituacaoProduto.Inativo)
            {
                throw new EntidadeInvalidaException("Produto", "Situação inválido.");
            }
            if (DataFabricacao.Date >= DataValidade.Date)
            {
                throw new EntidadeInvalidaException("Produto", "A Data de Fabricação não pode ser maior ou igual a Data de Validade.");
            }
            if (FornecedorCodigo == 0)
            {
                throw new EntidadeInvalidaException("Produto", "Código do Fornecedor inválido.");
            }
        }
    }
}