using System;

namespace GestaoDeProdutosAPI.Dominio.Exceptions
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase(string titulo, string mensagem) : base(mensagem)
        {
            Titulo = titulo;
            Mensagem = mensagem;
        }

        public string Titulo { get; set; }

        public string Mensagem { get; set; }
    }
}
