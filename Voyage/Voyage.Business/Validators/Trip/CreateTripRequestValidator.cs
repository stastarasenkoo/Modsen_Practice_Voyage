using FluentValidation;
using Voyage.Common.RequestModels.Trip;

namespace Voyage.Business.Validators.Trip;

public class CreateTripRequestValidator : AbstractValidator<CreateTripRequest>
{
    public CreateTripRequestValidator()
    {
        Include(new TripInfoValidator());
    }
}
