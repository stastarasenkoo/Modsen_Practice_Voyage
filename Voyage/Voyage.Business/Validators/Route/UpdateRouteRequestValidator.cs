using FluentValidation;
using Voyage.Common.RequestModels.Route;

namespace Voyage.Business.Validators.Route;

public class UpdateRouteRequestValidator : AbstractValidator<UpdateRouteRequest>
{
    public UpdateRouteRequestValidator()
    {
        Include(new RouteInfoValidator());
        RuleFor(r => r.Id).NotEmpty();
    }
}
