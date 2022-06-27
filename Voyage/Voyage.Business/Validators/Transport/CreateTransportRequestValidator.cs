using FluentValidation;
using Voyage.Common.RequestModels;

namespace Voyage.Business.Validators.Transport
{
    public class CreateTransportRequestValidator : AbstractValidator<CreateTransportRequest>
    {
        public CreateTransportRequestValidator()
        {
            Include(new TransportInfoValidator());
            RuleFor(x => x.Mark).Length(2, 30);
            RuleFor(x => x.SeatsCount).GreaterThan(1);
            RuleFor(x => x.Type).IsInEnum();
        }
    }
}
