
using FluentValidation;

public class CreateBookCommandValidator: AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(BookErrors.TitileIsRequired);
        RuleFor(x => x.Isbn)
            .Length(13)
            .WithMessage(BookErrors.InvalidISBN);
    }
}