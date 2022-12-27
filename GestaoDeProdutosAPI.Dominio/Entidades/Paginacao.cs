using System.Collections.Generic;

namespace GestaoDeProdutosAPI.Dominio.Entidades
{
    public class Paginacao<T> where T : class
    {
        public int Total { get; set; }
        public List<T> Itens { get; set; }

        public Paginacao(int total, List<T> itens)
        {
            Total = total;
            Itens = itens;
        }
    }
}
