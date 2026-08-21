namespace CIWithJenkins.Exceptions
{
    public class RoleExceptions : DomainException
    {
        protected RoleExceptions(string message) : base(message)
        {
        }
        protected RoleExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    public class RoleNotFoundException : RoleExceptions
    {
        public RoleNotFoundException(Guid roleId) : base($"A role with ID {roleId} was not found.")
        {
        }
        public RoleNotFoundException(string message) : base(message)
        {
        }
        public override int StatusCode => StatusCodes.Status404NotFound;
        public override string Title => "Resource Not Found";
    }
}
