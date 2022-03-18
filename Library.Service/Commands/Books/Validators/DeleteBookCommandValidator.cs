using FluentValidation;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Books.Validators
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        private readonly LibraryDbContext _libraryDbContext;

        public DeleteBookCommandValidator(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
            RuleFor(c => c.Id).NotEmpty().WithMessage("Пустой Id");
            RuleFor(c => c.Id).MustAsync(IsIdNotFoound).WithMessage("Книги с таким Id не сущуствует");
        }

        private async Task<bool> IsIdNotFoound(int id, CancellationToken cancellationToken)
        {
            return await _libraryDbContext.Books.Select(b => b.BookId).ContainsAsync(id, cancellationToken);
        }
    }
}
