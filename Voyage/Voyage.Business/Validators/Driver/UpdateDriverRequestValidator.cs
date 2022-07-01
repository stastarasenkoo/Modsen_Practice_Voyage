using FluentValidation;
using Voyage.Common.RequestModels.Driver;

namespace Voyage.Business.Validators.Driver;

public class UpdateDriverRequestValidator : AbstractValidator<UpdateDriverRequest>
{
    public UpdateDriverRequestValidator()
    {
        Include(new DriverInfoValidator());

        RuleFor(d => d.UserId).NotEmpty();
    }
}
