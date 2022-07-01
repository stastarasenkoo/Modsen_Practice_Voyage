using System.Text.RegularExpressions;
using FluentValidation;
using Voyage.Common.RequestModels.Driver;

namespace Voyage.Business.Validators.Driver;

public class DriverInfoValidator : AbstractValidator<IDriverInfo>
{
    public DriverInfoValidator()
    {
        RuleFor(d => d.FirstName).NotEmpty();
        RuleFor(d => d.SecondName).NotEmpty();
        
        RuleFor(d => d).Must(d => 
        new Regex(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$").
        IsMatch(d.PhoneNumber));

        RuleFor(d => d.Email).EmailAddress();
        RuleFor(d => d.DrivingExperience).GreaterThanOrEqualTo(0);
        RuleFor(d => d.DriverCategory).IsInEnum();
    }
}
