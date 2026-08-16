namespace CIWithJenkins.Exceptions
{
    public class ProductExceptions : Exception
    {
        public ProductExceptions() : base() { }
        public ProductExceptions(string message) : base(message) { }
        public ProductExceptions(string message, Exception innerException)
            : base(message, innerException) { }
    }
    public class ProductNotFoundException : ProductExceptions
    {
        public ProductNotFoundException(Guid productId)
            : base($"Product with Id '{productId}' not found.") { }
        public ProductNotFoundException(string message) : base(message) { }
    }
}
