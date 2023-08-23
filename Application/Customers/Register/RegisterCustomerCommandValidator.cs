using FluentValidation;

namespace Application.Customers.Register;

internal class CreateCustomerAccountCommandValidator : AbstractValidator<RegisterCustomerCommand>
{
    public CreateCustomerAccountCommandValidator()
    {
        RuleFor(x=>x.Email).NotEmpty();

        RuleFor(x=>x.FirstName).NotEmpty().MaximumLength(255);

        RuleFor(x=>x.LastName).NotEmpty().MaximumLength(255);

        RuleFor(x => x.Password).NotEmpty().MaximumLength(255);

    }
}
