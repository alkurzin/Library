﻿using AutoMapper;
using Library.Domain.Books;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Queries.Books
{
    public class GetIssuedBookQuery : IRequest<IEnumerable<BookDto>>
    {
    }

    public class GetIssuedBookQueryHandler : IRequestHandler<GetIssuedBookQuery, IEnumerable<BookDto>>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public GetIssuedBookQueryHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookDto>> Handle(GetIssuedBookQuery command, CancellationToken cancellationToken)
        {
            return await _mapper.ProjectTo<BookDto>(_libraryDbContext.Books.Where(b => _libraryDbContext.Records.Select(r => r.BookId).Contains(b.BookId))).ToListAsync(cancellationToken);
        }
    }
}