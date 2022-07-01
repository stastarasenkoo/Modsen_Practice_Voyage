using FluentValidation;
using Voyage.Common.RequestModels.Ticket;

namespace Voyage.Business.Validators.Ticket;

public class TicketRequestValidator : AbstractValidator<TicketRequest>
{
    public TicketRequestValidator()
    {
        RuleFor(t => t.PassengerId).NotEmpty();
        RuleFor(t => t.TripId).GreaterThanOrEqualTo(1);
    }
}
