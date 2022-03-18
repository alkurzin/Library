using AutoMapper;
using Library.Domain.Books;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Queries.Books
{
    public class GetBookQuery : IRequest<IEnumerable<BookDto>>
    {
    }

    public class GetBookQueryHandler : IRequestHandler<GetBookQuery, IEnumerable<BookDto>>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetBookQuery command, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<BookDto>(_libraryDbContext.Books).ToListAsync(cancellationToken);
        }
    }
}
