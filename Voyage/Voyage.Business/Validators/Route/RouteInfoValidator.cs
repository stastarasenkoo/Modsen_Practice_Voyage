using FluentValidation;
using Voyage.Common.RequestModels.Route;

namespace Voyage.Business.Validators.Route;

public class RouteInfoValidator : AbstractValidator<IRouteInfo>
{
    public RouteInfoValidator()
    {
        RuleFor(r => r.Name).Length(3, 100);
        RuleFor(r => r.DepartureAddress).Length(5, 200);
        RuleFor(r => r.DestinationAddress).Length(5, 200);
        RuleFor(r => r.BasePrice).GreaterThanOrEqualTo(0.01M);
        RuleFor(r => r.StopsCount).GreaterThanOrEqualTo(1);
        RuleFor(r => r.Distance).GreaterThan(0);
    }
}
