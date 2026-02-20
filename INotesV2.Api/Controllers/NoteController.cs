using INotesV2.Api.Shared;
using INotesV2.Application.Commands.Note.CreateNote;
using INotesV2.Application.Commands.Note.DeleteNote;
using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Models;
using INotesV2.Application.Queries.Note.GetListingNote;
using INotesV2.Application.Queries.Note.GetNote;
using INotesV2.Application.Requests.Note;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INotesV2.Api.Controllers
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : ApiBaseController
    {
        public NoteController(ISender sender) : base(sender) { }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteRequest command, CancellationToken cancellationToken)
        {
            var request = command.createNoteCommand(opt_user_id);
            var result = await sender.Send(request, cancellationToken);
            return HandleResponse(result);
        }

        [Authorize]
        [HttpGet("get/{id:guid}")]
        public async Task<ActionResult<NoteDto>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetNoteQuery(user_id,id);
            var result = await sender.Send(request, cancellationToken);
            return HandleResponse(result);
        }

        [Authorize]
        [HttpGet("list")]
        public async Task<ActionResult<CursorPagedResult<NoteDto>>> GetListing([FromQuery] GetListingNoteRequest command, CancellationToken cancellationToken)
        {
            var request = command.GetListingNoteQuery(user_id);
            var result = await sender.Send(request, cancellationToken);
            return HandleResponse(result);
        }

        [Authorize]
        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteNoteCommand(id, user_id);
            var result = await sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [Authorize]
        [HttpPut("update/{id:guid}")]
        public async Task<ActionResult<UpdateNoteDto>> Update([FromRoute] Guid id, [FromBody] UpdateNoteRequest request, CancellationToken cancellationToken)
        {
            var command = request.UpdateNoteCommand(user_id, id);
            var result = await sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

    }
}