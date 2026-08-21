namespace CIWithJenkins.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message) : base(message) { }
        protected DomainException(string message, Exception innerException)
            : base(message, innerException) { }
        public virtual int StatusCode => StatusCodes.Status400BadRequest;
        public virtual string Title => "Invalid Request";
    }
}
