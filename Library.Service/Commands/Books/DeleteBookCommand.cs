using Library.Domain.Books;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Books
{
    public class DeleteBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Unit>
    {
        private readonly LibraryDbContext _libraryDbContext;

        public DeleteBookCommandHandler(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<Unit> Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _libraryDbContext.Books.Where(c => c.BookId == command.Id).FirstOrDefaultAsync(cancellationToken);

            _libraryDbContext.Books.Remove(book);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
