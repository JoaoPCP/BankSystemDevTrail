namespace ProjetoDevTrail.Api.Utills.Exceptions
{
    public class NotFoundException : ExceptionWithStatusCode
    {
        public NotFoundException(string message)
            : base(message, statusCode: 404) { }
    }
}
