namespace GestaoDeProdutosAPI.Dominio.Exceptions
{
    public class RegistroNaoEncontradoException : ExceptionBase
    {
        public RegistroNaoEncontradoException(string titulo, string mensagem) : base(titulo, mensagem)
        {
        }
    }
}
