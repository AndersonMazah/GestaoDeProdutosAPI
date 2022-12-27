using GestaoDeProdutosAPI.Dominio.Exceptions;
using GestaoDeProdutosAPI.Dominio.Interface;
using GestaoDeProdutosAPI.Dominio.Validacoes;

namespace GestaoDeProdutosAPI.Dominio.Entidades
{
    public class Fornecedor : EntidadeBase, IEntidade
    {
        public string Descricao { get; private set; }

        public string CNPJ { get; private set; }

        protected Fornecedor() { }

        public Fornecedor(int codigo, string descricao, string cnpj)
        {
            Codigo = codigo;
            Descricao = descricao;
            CNPJ = cnpj;
            Validar();
        }

        public void Validar()
        {
            if (Codigo == 0)
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
