namespace ProjetoDevTrail.Application.Utils.Exceptions
{
    public class BadRequestException : ExceptionWithStatusCode
    {
        public BadRequestException(string message)
            : base(message, 400) { }
    }
}
