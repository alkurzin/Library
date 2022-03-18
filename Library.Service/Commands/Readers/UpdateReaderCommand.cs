using AutoMapper;
using Library.Domain.Readers;
using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Readers
{
    public class UpdateReaderCommand : IRequest<ReaderDto>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class UpdpateReaderCommandHandler : IRequestHandler<UpdateReaderCommand, ReaderDto>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public UpdpateReaderCommandHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<ReaderDto> Handle(UpdateReaderCommand command, CancellationToken cancellationToken)
        {
            var reader = await _libraryDbContext.Readers.Where(c => c.ReaderId == command.Id).FirstOrDefaultAsync(cancellationToken);

            reader.Update(command.FullName, command.BirthDate);

            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<ReaderDto>(reader);
        }
    }
}