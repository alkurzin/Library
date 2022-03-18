using AutoMapper;
using Library.Domain.Books;
using Library.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Books
{
    public class AddBookCommand : IRequest<BookDto>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Article { get; set; }
        public int PublicationYear { get; set; }
        public int Amount { get; set; }
    }

    public class AddBookCommandHandler : IRequestHandler<AddBookCommand, BookDto>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public AddBookCommandHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }
        public async Task<BookDto> Handle(AddBookCommand command, CancellationToken cancellationToken)
        {
            var book = new Book(command.Title, command.Author, command.Article, command.PublicationYear, command.Amount);

            await _libraryDbContext.AddAsync(book);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<BookDto>(book);
        }
    }
}
