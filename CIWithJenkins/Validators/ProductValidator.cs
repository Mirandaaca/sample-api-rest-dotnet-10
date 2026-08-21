using CIWithJenkins.DTOs.Products;
using FluentValidation;

namespace CIWithJenkins.Validators
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(150).WithMessage("The name cannot exceed 150 characters.");

            RuleFor(product => product.Brand)
                .NotEmpty().WithMessage("Brand is required.")
                .MaximumLength(100).WithMessage("The brand cannot exceed 100 characters.");

            RuleFor(product => product.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("The quantity cannot be negative.");

            RuleFor(product => product.Price)
                .GreaterThan(0).WithMessage("The price must be greater than zero.");
        }
    }
}
