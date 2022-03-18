using FluentValidation;

namespace Library.Service.Commands.Books.Validators
{
    public class AddBookCommandValidator : AbstractValidator<AddBookCommand>
    {
        public AddBookCommandValidator()
        {
            RuleFor(c => c.Author).NotEmpty().WithMessage("Автор пуст");
            RuleFor(c => c.Article).NotEmpty().WithMessage("Артикль пуст");
            RuleFor(c => c.Title).NotEmpty().WithMessage("Название отсутствует");
            RuleFor(c => c.PublicationYear).NotEmpty().WithMessage("Отсутствует год публикации");
            RuleFor(c => c.Amount).NotEmpty().WithMessage("Количество не задано");
        }
    }
}
