using AutoMapper;
using Library.Domain.Records;
using Library.Infrastructure;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Readers
{
    public class AddRecordCommand : IRequest<RecordDto>
    {
        public int ReaderId { get; set; }
        public int BookId { get; set; }
    }

    public class AddRecordCommandHandler : IRequestHandler<AddRecordCommand, RecordDto>
    {
        private readonly LibraryDbContext _libraryDbContext;
        private readonly IMapper _mapper;

        public AddRecordCommandHandler(LibraryDbContext libraryDbContext, IMapper mapper)
        {
            _libraryDbContext = libraryDbContext;
            _mapper = mapper;
        }

        public async Task<RecordDto> Handle(AddRecordCommand command, CancellationToken cancellationToken)
        {
            var record = new Record(command.ReaderId, command.BookId);

            await _libraryDbContext.AddAsync(record);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return _mapper.Map<RecordDto>(record);
        }
    }

}