namespace CIWithJenkins.Exceptions
{
    /// <summary>
    /// Familia de excepciones del módulo de productos.
    /// </summary>
    public abstract class ProductExceptions : DomainException
    {
        protected ProductExceptions(string message) : base(message) { }
        protected ProductExceptions(string message, Exception innerException)
            : base(message, innerException) { }
    }

    public class ProductNotFoundException : ProductExceptions
    {
        public ProductNotFoundException(Guid productId)
            : base($"A product with Id '{productId}' was not found.") { }
        public ProductNotFoundException(string message) : base(message) { }
        public override int StatusCode => StatusCodes.Status404NotFound;
        public override string Title => "Resource not found";
    }
}
