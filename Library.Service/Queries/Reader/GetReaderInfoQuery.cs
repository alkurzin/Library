using AutoMapper;
using Library.Domain.Readers;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Queries.Reader
{
    public class GetReaderInfoQuery : IRequest<ReaderInfoDto>
    {
        public int Id { get; set; }
    }

    public class GetReaderInfoQueryHandler : IRequestHandler<GetReaderInfoQuery, ReaderInfoDto>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetReaderInfoQueryHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<ReaderInfoDto> Handle(GetReaderInfoQuery command, CancellationToken cancellationToken)
        {
            var reader = await _libraryDbContext.Readers.Where(r => r.ReaderId == command.Id).FirstOrDefaultAsync(cancellationToken);
            var books = await _libraryDbContext.Books.Join(_libraryDbContext.Records.Where(r => r.ReaderId == command.Id), b => b.BookId, r => r.BookId, (b, r) => b).ToListAsync(cancellationToken);
            var readerInfo = new ReaderInfoDto(reader, books);

            return readerInfo;
        }
    }
}
