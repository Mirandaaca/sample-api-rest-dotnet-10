using CIWithJenkins.DTOs.Clients;
using FluentValidation;

namespace CIWithJenkins.Validators
{
    public class ClientValidator : AbstractValidator<ClientDTO>
    {
        public ClientValidator()
        {
            RuleFor(client => client.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("The name cannot exceed 100 characters.");

            RuleFor(client => client.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(100).WithMessage("The surname cannot exceed 100 characters.");

            RuleFor(client => client.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("The email address is not in a valid format.")
                .MaximumLength(150).WithMessage("The email address cannot exceed 150 characters.");

            RuleFor(client => client.Phone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^\+?[0-9][0-9\s-]{6,19}$")
                .WithMessage("The phone number only accepts digits, spaces and hyphens, with an optional '+' prefix.");
        }
    }
}
