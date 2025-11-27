namespace ProjetoDevTrail.Application.Utils.Exceptions
{
    public class NotFoundException : ExceptionWithStatusCode
    {
        public NotFoundException(string message)
            : base(message, statusCode: 404) { }
    }
}
