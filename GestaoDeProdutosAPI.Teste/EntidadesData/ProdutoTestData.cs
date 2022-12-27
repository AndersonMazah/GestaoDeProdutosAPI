using GestaoDeProdutosAPI.Dominio.Enumeradores;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GestaoDeProdutosAPI.Teste.EntidadesData
{
    public class ProdutoTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, "", SituacaoProduto.Ativo, DateTime.Now, DateTime.Now, 1, "Código inválido." };
            yield return new object[] { 1, "", SituacaoProduto.Ativo, DateTime.Now, DateTime.Now, 1, "Descrição não pode ser nulo." };
            yield return new object[] { 1, "Descricao", SituacaoProduto.Ativo, DateTime.Now.AddDays(1), DateTime.Now, 1, "A Data de Fabricação não pode ser maior ou igual a Data de Validade." };
            yield return new object[] { 1, "Descricao", SituacaoProduto.Ativo, DateTime.Now, DateTime.Now, 1, "A Data de Fabricação não pode ser maior ou igual a Data de Validade." };
            yield return new object[] { 1, "Descricao", SituacaoProduto.Ativo, DateTime.Now.AddDays(-1), DateTime.Now, 0, "Código do Fornecedor inválido." };
        }
    }
}