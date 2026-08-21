namespace CIWithJenkins.Exceptions
{
    public abstract class ClientExceptions : DomainException
    {
        protected ClientExceptions(string message) : base(message) { }
        protected ClientExceptions(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class ClientNotFoundException : ClientExceptions
    {
        public ClientNotFoundException(Guid clientId)
            : base($"A client with Id '{clientId}' was not found.") { }
        public ClientNotFoundException(string message) : base(message) { }
        public override int StatusCode => StatusCodes.Status404NotFound;
        public override string Title => "Resource not found";
    }
}
