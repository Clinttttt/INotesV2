using INotesV2.Api.Shared;
using INotesV2.Application.Commands.Note.CreateNote;
using INotesV2.Application.Requests.Note;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INotesV2.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ApiBaseController
    {
        public NoteController(ISender sender) : base(sender) { }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteRequest command, CancellationToken cancellationToken)
        {
            var request = command.createNoteCommand(UserIdOrNull);
            var result = await _sender.Send(request, cancellationToken);
            return HandleResponse(result);
        }

        [Authorize]
        [HttpPost("getlisting")]
        public async Task<ActionResult<Guid>> GetListing([FromBody] GetListingNoteRequest command, CancellationToken cancellationToken)
        {
            var request = command.GetListingNoteQuery(UserId);
            var result = await _sender.Send(request, cancellationToken);
            return HandleResponse(result);
        }
    }

}