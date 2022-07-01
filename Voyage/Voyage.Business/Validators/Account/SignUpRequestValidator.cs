using System.Text.RegularExpressions;
using FluentValidation;
using Voyage.Common.RequestModels.Account;

namespace Voyage.Business.Validators.Account;
public class SignUpRequestValidator : AbstractValidator<SignUpRequestModel>
{
    public SignUpRequestValidator()
    {
        RuleFor(d => d.FirstName).NotEmpty();
        RuleFor(d => d.SecondName).NotEmpty();

        RuleFor(d => d).Must(d =>
        new Regex(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$").
        IsMatch(d.PhoneNumber));

        RuleFor(r => r.Email).EmailAddress();

        RuleFor(r => r.UserName).NotEmpty();

        RuleFor(r => r.Password).NotEmpty();
    }
}
