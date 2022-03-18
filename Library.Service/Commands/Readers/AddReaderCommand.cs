using AutoMapper;
using Library.Domain.Readers;
using Library.Infrastructure;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Readers
{
    public class AddReaderCommand : IRequest<ReaderDto>
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class AddReaderCommandHandler : IRequestHandler<AddReaderCommand, ReaderDto>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public AddReaderCommandHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<ReaderDto> Handle(AddReaderCommand command, CancellationToken cancellationToken)
        {
            var reader = new Reader(command.FullName, command.BirthDate);

            await _libraryDbContext.AddAsync(reader);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ReaderDto>(reader);
        }
    }
}
