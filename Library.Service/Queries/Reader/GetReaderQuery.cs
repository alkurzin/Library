using AutoMapper;
using Library.Domain.Readers;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Queries.Reader
{
    public class GetReaderQuery : IRequest<IEnumerable<ReaderDto>>
    {
    }

    public class GetReaderQueryHandler : IRequestHandler<GetReaderQuery, IEnumerable<ReaderDto>>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetReaderQueryHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReaderDto>> Handle(GetReaderQuery command, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<ReaderDto>(_libraryDbContext.Readers).ToListAsync(cancellationToken);
        }
    }
}