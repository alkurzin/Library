using Library.Domain.Books;
using Library.Service.Commands.Books;
using Library.Service.Queries.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<BookDto> AddBook ([FromBody] AddBookCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<BookDto> UpdateBook([FromBody] UpdateBookCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{Id}")]
        public async Task<Unit> DeleteBook([FromRoute] DeleteBookCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{Id}")]
        public async Task<BookDto> GetBookById([FromRoute] GetBookByIdQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("")]
        public async Task<IEnumerable<BookDto>> GetBook([FromRoute] GetBookQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("issued")]
        public async Task<IEnumerable<BookDto>> GetIssuedBook([FromRoute] GetIssuedBookQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("available")]
        public async Task<IEnumerable<BookDto>> GetAvailableBook([FromRoute] GetAvailableBookQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("searchBook/{SearchStr}")]
        public async Task<IEnumerable<BookDto>> GetSearchBook([FromRoute] GetSearchBookQuery command)
        {
            return await _mediator.Send(command);
        }
    }
}