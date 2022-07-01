using FluentValidation;
using Voyage.Common.RequestModels.Trip;

namespace Voyage.Business.Validators.Trip;

public class UpdateTripRequestValidator : AbstractValidator<UpdateTripRequest>
{
    public UpdateTripRequestValidator()
    {
        Include(new TripInfoValidator());
        RuleFor(utr => utr.Id).NotEmpty();
    }
}
