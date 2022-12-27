using GestaoDeProdutosAPI.Dominio.Enumeradores;
using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Dominio.Interface;
using GestaoDeProdutosAPI.Dominio.Modelos;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeProdutosAPI.Dominio.Entidades
{
    [Table("produto")]
    public class Produto : EntidadeBase, IEntidade
    {
        [Column("descricao", TypeName = "NVARCHAR(50)")]
        public string Descricao { get; private set; }

        [Column("situacao", TypeName = "int")]
        public SituacaoProduto Situacao { get; private set; }

        [Column("datafabricacao", TypeName = "DATETIME")]
        public DateTime DataFabricacao { get; private set; }

        [Column("datavalidade", TypeName = "DATETIME")]
        public DateTime DataValidade { get; private set; }

        [Column("idfornecedor", TypeName = "INT")]
        public int FornecedorCodigo { get; private set; }
        public virtual Fornecedor Fornecedor { get; private set; }

        protected Produto() { }

        public Produto(int codigo, string descricao, SituacaoProduto situacao, DateTime dataFabricacao, DateTime dataValidade, int fornecedorCodigo)
        {
            Codigo = codigo;
            Descricao = descricao;
            Situacao = situacao;
            DataFabricacao = dataFabricacao;
            DataValidade = dataValidade;
            FornecedorCodigo = fornecedorCodigo;
            Validar(false);
        }

        public Produto(CadastroProdutoModel modelo)
        {
            Descricao = modelo.Descricao;
            Situacao = modelo.Situacao;
            DataFabricacao = modelo.DataFabricacao;
            DataValidade = modelo.DataValidade;
            FornecedorCodigo = modelo.FornecedorCodigo;
            Validar(true);
        }

        public void Atualizar(AtualizaProdutoModel modelo)
        {
            Descricao = modelo.Descricao;
            Situacao = modelo.Situacao;
            DataFabricacao = modelo.DataFabricacao;
            DataValidade = modelo.DataValidade;
            FornecedorCodigo = modelo.FornecedorCodigo;
            Validar(false);
        }

        public void MarcarComoDeletado()
        {
            Situacao = SituacaoProduto.Inativo;
        }

        public void Validar(bool isNovoRegistro = false)
        {
            if (!isNovoRegistro && Codigo == 0)
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