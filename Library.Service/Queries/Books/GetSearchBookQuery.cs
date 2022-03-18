using AutoMapper;
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

namespace Library.Service.Queries.Books
{
    public class GetSearchBookQuery : IRequest<IEnumerable<BookDto>>
    {
        public string SearchStr { get; set; }
    }

    public class GetSearchBookQueryHandler : IRequestHandler<GetSearchBookQuery, IEnumerable<BookDto>>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetSearchBookQueryHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetSearchBookQuery command, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<BookDto>(_libraryDbContext.Books
                .Where(x => x.Title.Contains(command.SearchStr)))
                .ToListAsync(cancellationToken);
        }
    }
}