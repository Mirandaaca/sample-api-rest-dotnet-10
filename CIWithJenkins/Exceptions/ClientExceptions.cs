namespace CIWithJenkins.Exceptions
{
    public class ClientExceptions : Exception
    {
        public ClientExceptions() : base() { }

        public ClientExceptions(string message) : base(message) { }

        public ClientExceptions(string message, Exception innerException) 
            : base(message, innerException) { }
    }

    public class ClientNotFoundException : ClientExceptions 
    {
        public ClientNotFoundException(Guid clientId) 
            : base($"Client with Id '{clientId}' not found.") { }

        public ClientNotFoundException(string message) : base(message) { }
    }
}
