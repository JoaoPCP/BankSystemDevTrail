namespace ProjetoDevTrail.Application.Utils.Exceptions
{
    public abstract class ExceptionWithStatusCode : Exception
    {
        public int StatusCode { get; }

        protected ExceptionWithStatusCode(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
