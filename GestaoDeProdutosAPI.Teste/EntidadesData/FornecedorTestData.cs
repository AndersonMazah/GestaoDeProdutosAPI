using System.Collections;
using System.Collections.Generic;

namespace GestaoDeProdutosAPI.Teste.EntidadesData
{
    public class FornecedorTestData : IEnumerable<object[]>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 0, "", "", "Código inválido." };
            yield return new object[] { 1, "","", "Descrição não pode ser nulo." };
            yield return new object[] { 1, "Descricao", "", "CNPJ inválido." };
            yield return new object[] { 1, "Descricao", "12.218.718/0001-39", "CNPJ inválido." };
        }
    }
}
