using Library.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Service.Commands.Readers
{
    public class DeleteReaderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }

    public class DeleteReaderCommandHandler : IRequestHandler<DeleteReaderCommand, Unit>
    {
        private readonly LibraryDbContext _libraryDbContext;

        public DeleteReaderCommandHandler(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        public async Task<Unit> Handle(DeleteReaderCommand command, CancellationToken cancellationToken)
        {
            var reader = await _libraryDbContext.Readers.Where(c => c.ReaderId == command.Id).FirstOrDefaultAsync(cancellationToken);

            _libraryDbContext.Readers.Remove(reader);
            await _libraryDbContext.SaveChangesAsync(cancellationToken);

            return new Unit();
        }
    }
}
