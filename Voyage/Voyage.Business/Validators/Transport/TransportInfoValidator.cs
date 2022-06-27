using FluentValidation;
using Voyage.Common.RequestModels;

namespace Voyage.Business.Validators.Transport
{
    public class TransportInfoValidator : AbstractValidator<ITransportInfo>
    {
        public TransportInfoValidator()
        {
            RuleFor(x => x.Color).IsInEnum();
            RuleFor(x => x.Number).Length(8);
            RuleFor(x => x.PriceRate).GreaterThanOrEqualTo(1);
        }
    }
}
