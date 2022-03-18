using AutoMapper;
using Library.Domain.Books;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Queries.Books
{
    public class GetBookByIdQuery : IRequest<BookDto>
    {
        public int Id { get; set; }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, BookDto>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookByIdQuery command, CancellationToken cancellationToken)
        {
            return _mapper.Map<BookDto>(await _libraryDbContext.Books
                .Where(c => c.BookId == command.Id)
                .FirstOrDefaultAsync(cancellationToken));
        }
    }
}
