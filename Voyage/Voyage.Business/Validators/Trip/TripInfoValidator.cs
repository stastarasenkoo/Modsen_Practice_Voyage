using FluentValidation;
using Voyage.Common.RequestModels.Trip;

namespace Voyage.Business.Validators.Trip;

public class TripInfoValidator : AbstractValidator<ITripInfo>
{
    public TripInfoValidator()
    {
        RuleFor(t => t.RouteId).NotEmpty();
        RuleFor(t => t.DriverId).NotEmpty();
        RuleFor(t => t.TransportId).NotEmpty();

        RuleFor(t => t.DepartureTime).NotEmpty();
        RuleFor(t => t.ArrivalTime).NotEmpty();
        RuleFor(t => t).Must(t => t.DepartureTime > DateTime.Now && t.DepartureTime < t.ArrivalTime);

        RuleFor(t => t.Description).Length(0, 500).When(t => !string.IsNullOrEmpty(t.Description));

        RuleFor(t => t).Must(t => t.FinalPrice is >= 0.01M);

        RuleFor(t => t.FreeSeats).GreaterThan(0);
    }
}
