using FluentValidation;
using Voyage.Common.RequestModels.Route;

namespace Voyage.Business.Validators.Route;

public class CreateRouteRequestValidator : AbstractValidator<CreateRouteRequest>
{
    public CreateRouteRequestValidator()
    {
        Include(new RouteInfoValidator());
    }
}
