using Library.Domain.Readers;
using Library.Domain.Records;
using Library.Service.Commands.Readers;
using Library.Service.Queries.Reader;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : Controller
    {
        private readonly IMediator _mediator;

        public ReaderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ReaderDto> AddReader([FromBody] AddReaderCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("")]
        public async Task<IEnumerable<ReaderDto>> GetReader([FromRoute] GetReaderQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut]
        public async Task<ReaderDto> UpdateReader([FromBody] UpdateReaderCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{Id}")]
        public async Task<Unit> DeleteReader([FromRoute] DeleteReaderCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost("issue")]
        public async Task<RecordDto> AddRecord([FromBody] AddRecordCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("return")]
        public async Task<Unit> DeleteRecord([FromBody] DeleteRecordCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("{Id}")]
        public async Task<ReaderInfoDto> GetReaderInfo([FromRoute] GetReaderInfoQuery command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet("searchReader/{SearchStr}")]
        public async Task<IEnumerable<ReaderInfoDto>> GetSearchReaderInfo([FromRoute] GetSearchReaderInfoQuery command)
        {
            return await _mediator.Send(command);
        }
    }
}