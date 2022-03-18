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
    public class GetSearchReaderInfoQuery : IRequest<IEnumerable<ReaderInfoDto>>
    {
        public string SearchStr { get; set; }
    }

    public class GetSearchReaderInfoQueryHandler : IRequestHandler<GetSearchReaderInfoQuery, IEnumerable<ReaderInfoDto>>
    {
        private readonly LibraryDbContext _libraryDbContext;

        public GetSearchReaderInfoQueryHandler(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<IEnumerable<ReaderInfoDto>> Handle(GetSearchReaderInfoQuery command, CancellationToken cancellationToken)
        {
            var readers = await _libraryDbContext.Readers.Where(r => r.FullName.Contains(command.SearchStr)).ToListAsync(cancellationToken);
            var result = new List<ReaderInfoDto>();
            
            foreach( var reader in readers)
            {
                var books = await _libraryDbContext.Books.Join(_libraryDbContext.Records.Where(r => r.ReaderId == reader.ReaderId), b => b.BookId, r => r.BookId, (b, r) => b).ToListAsync(cancellationToken);
                var readerInfo = new ReaderInfoDto(reader, books);
                result.Add(readerInfo);
            }

            return result;
        }
    }
}