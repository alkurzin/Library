using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Readers
{
    public class DeleteRecordCommand : IRequest<Unit>
    {
        public int ReaderId { get; set; }
        public int BookId { get; set; }
    }
    public class DeleteRecordCommandHandler : IRequestHandler<DeleteRecordCommand, Unit>
    {
        private readonly LibraryDbContext _libraryDbContext;

        public DeleteRecordCommandHandler(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<Unit> Handle(DeleteRecordCommand command, CancellationToken cancellationToken)
        {
            var record = await _libraryDbContext.Records.Where(c => c.ReaderId == command.ReaderId && c.BookId == command.BookId).FirstOrDefaultAsync(cancellationToken);

            _libraryDbContext.Records.Remove(record);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}