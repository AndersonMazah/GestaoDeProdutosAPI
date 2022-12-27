namespace GestaoDeProdutosAPI.Dominio.Exceptions
{
    public class EntidadeInvalidaException : ExceptionBase
    {
        public EntidadeInvalidaException(string titulo, string mensagem) : base(titulo, mensagem)
        {
        }
    }
}