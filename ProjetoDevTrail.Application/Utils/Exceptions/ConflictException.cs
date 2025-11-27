namespace ProjetoDevTrail.Application.Utils.Exceptions
{
    public class ConflictException: ExceptionWithStatusCode
    {
        public ConflictException(string message)
            : base(message, statusCode: 409) { }
    }
    {
    }
}
