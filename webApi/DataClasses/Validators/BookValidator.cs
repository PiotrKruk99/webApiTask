using FluentValidation;
using webApi.DataClasses.Entities;

namespace webApi.Validators;

public class BookValidator : AbstractValidator<BookCl>
{
    public BookValidator()
    {
        RuleFor(b => b.Title)
    }
}