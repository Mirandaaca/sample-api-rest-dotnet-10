using CIWithJenkins.DTOs.Roles;
using FluentValidation;

namespace CIWithJenkins.Validators
{
    public class RoleValidator: AbstractValidator<RoleDTO>
    {
        public RoleValidator()
        {
            RuleFor(role => role.Name)
                .NotEmpty().WithMessage("The role name is required.")
                .MaximumLength(100).WithMessage("The role name cannot exceed 100 characters.");
            RuleFor(role => role.Description)
                .MaximumLength(250).WithMessage("The role description cannot exceed 250 characters.");
        }
    }
}
