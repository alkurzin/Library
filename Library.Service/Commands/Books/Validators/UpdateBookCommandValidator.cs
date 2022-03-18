using FluentValidation;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Books.Validators
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        private readonly LibraryDbContext _libraryDbContext;

        public UpdateBookCommandValidator(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
            RuleFor(c => c.Id).NotEmpty().WithMessage("Id пуст");
            RuleFor(c => c.Author).NotEmpty().WithMessage("Автор пуст");
            RuleFor(c => c.Article).NotEmpty().WithMessage("Артикль пуст");
            RuleFor(c => c.Title).NotEmpty().WithMessage("Название отсутствует");
            RuleFor(c => c.PublicationYear).NotEmpty().WithMessage("Отсутствует год публикации");
            RuleFor(c => c.Amount).NotEmpty().WithMessage("Количество не задано");
            RuleFor(c => c.Id).MustAsync(IsIdNotFoound).WithMessage("Книги с таким Id не сущуствует");
        }

        private async Task<bool> IsIdNotFoound(int id, CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Books.Select(b => b.BookId).ContainsAsync(id, cancellationToken);

        }
    }
}
