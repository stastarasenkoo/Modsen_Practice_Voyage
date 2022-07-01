using FluentValidation;
using Voyage.Common.RequestModels.Transport;

namespace Voyage.Business.Validators.Transport
{
    public class UpdateTransportRequestValidator : AbstractValidator<UpdateTransportRequest>
    {
        public UpdateTransportRequestValidator()
        {
            Include(new TransportInfoValidator());
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
