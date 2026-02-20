using INotesV2.Api.Shared;
using INotesV2.Application.Dtos.Tag;
using INotesV2.Application.Queries.Tag.GetListingTag;
using INotesV2.Application.Requests.Tag;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INotesV2.Api.Controllers
{
    [Route("api/tag")]
    [ApiController]
    public class TagController : ApiBaseController
    {
        public TagController(ISender sender) : base(sender) { }

        [Authorize]
        [HttpPost("create")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTagRequest request, CancellationToken cancellationToken)
        {
            var command = request.CreateTagCommand(user_id);
            var result = await sender.Send(command, cancellationToken);
            return HandleResponse(result);

        }

        [Authorize]
        [HttpDelete("delete/{id:guid}")]
        public async Task<ActionResult<bool>> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var command = new Application.Commands.Tag.DeleteTag.DeleteTagCommand(user_id, id);
            var result = await sender.Send(command, cancellationToken);
            return HandleResponse(result);
        }

        [Authorize]
        [HttpGet("listing")]
        public async Task<ActionResult<List<TagDto>>> GetListing(CancellationToken cancellationToken)
        {
            var query = new GetListingTagQuery(user_id);
            var result = await sender.Send(query, cancellationToken);
            return HandleResponse(result);
        }

        [Authorize]
        [HttpPost("add_note_tag")]
        public async Task<ActionResult<bool>> AddTagToNote([FromBody] AddTagToNoteRequest request, CancellationToken cancellationToken)
        {
            var command = request.AddTagToNoteCommand(user_id);
            var result = await sender.Send(command, cancellationToken);
            return HandleResponse(result);

        }
    }
}
