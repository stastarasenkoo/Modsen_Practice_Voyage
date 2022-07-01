using FluentValidation;
using Voyage.Common.RequestModels.Driver;

namespace Voyage.Business.Validators.Driver;

public class CreateDriverRequestValidator : AbstractValidator<CreateDriverRequest>
{
    public CreateDriverRequestValidator()
    {
        Include(new DriverInfoValidator());

        RuleFor(d => d.UserName).NotEmpty();
        RuleFor(d => d.Password).NotEmpty();
    }
}
