using FluentValidation;
using webApi.DataClasses.Entities;

namespace webApi.Validators;

public class WriterValidator : AbstractValidator<WriterCl>
{
    public WriterValidator()
    {
        RuleFor(w => w.FullName).NotEmpty();
        RuleFor(w => w.Country).NotEmpty();
    }
}