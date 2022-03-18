using AutoMapper;
using Library.Domain.Books;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Books
{
    public class UpdateBookCommand : IRequest<BookDto>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Article { get; set; }
        public int PublicationYear { get; set; }
        public int Amount { get; set; }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BookDto>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var book = await _libraryDbContext.Books.Where(c => c.BookId == command.Id).FirstOrDefaultAsync(cancellationToken);

            book.Update(command.Title, command.Author, command.Article, command.PublicationYear, command.Amount);

            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BookDto>(book);
        }
    }
}
