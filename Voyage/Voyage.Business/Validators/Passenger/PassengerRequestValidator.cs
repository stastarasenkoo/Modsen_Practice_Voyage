using FluentValidation;
using Voyage.Common.RequestModels.Passenger;

namespace Voyage.Business.Validators.Passenger;

public class PassengerRequestValidator : AbstractValidator<PassengerRequest>
{
    public PassengerRequestValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.Points).GreaterThanOrEqualTo(1);
    }
}
