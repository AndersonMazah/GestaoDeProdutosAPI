using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Dominio.Interface;
using GestaoDeProdutosAPI.Dominio.Modelos;
using GestaoDeProdutosAPI.Dominio.Validacoes;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoDeProdutosAPI.Dominio.Entidades
{
    [Table("fornecedor")]
    public class Fornecedor : EntidadeBase, IEntidade
    {
        [Column("descricao", TypeName = "NVARCHAR(50)")]
        public string Descricao { get; private set; }

        [Column("cnpj", TypeName = "NVARCHAR(18)")]
        public string CNPJ { get; private set; }

        protected Fornecedor() { }

        public Fornecedor(int codigo, string descricao, string cnpj)
        {
            Codigo = codigo;
            Descricao = descricao;
            CNPJ = cnpj;
            Validar(false);
        }

        public Fornecedor(CadastroFornecedorModel modelo)
        {
            Descricao = modelo.Descricao;
            CNPJ = modelo.CNPJ;
            Validar(true);
        }

        public void Atualizar(AtualizaFornecedorModel modelo)
        {
            Descricao = modelo.Descricao;
            CNPJ = modelo.CNPJ;
            Validar(false);
        }

        public void Validar(bool isNovoRegistro = false)
        {
            if (!isNovoRegistro && Codigo == 0)
            {
                throw new EntidadeInvalidaException("Fornecedor", "Código inválido.");
            }
            if (string.IsNullOrWhiteSpace(Descricao))
            {
                throw new EntidadeInvalidaException("Fornecedor", "Descrição não pode ser nulo.");
            }
            if (string.IsNullOrWhiteSpace(CNPJ) || !ValidaCNPJ.IsCnpj(CNPJ))
            {
                throw new EntidadeInvalidaException("Fornecedor", "CNPJ inválido.");
            }
        }
    }
}
