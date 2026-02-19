using INotesV2.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace INotesV2.Api.Shared
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiBaseController : ControllerBase
    {

        public readonly ISender _sender;
        public ApiBaseController(ISender sender)
        {
            _sender = sender;
        }   
        protected ISender Sender => _sender;

        protected Guid? UserIdOrNull
        {
            get
            {
                var user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                return Guid.TryParse(user_id, out var id) ? id : null;
            } 
        }
        protected Guid UserId => UserIdOrNull ?? throw new UnauthorizedAccessException("User ID not found in claims.");


        public ActionResult<Result<T>> HandleResponse<T>(Result<T> result, string? message = null)
        {
            if(result.status_code == 200)
            {
                return Ok(result);
            }
            return result.status_code switch
            {
                400 => result.validation_errors != null && result.validation_errors.Any() ? BadRequest(new
                {
                    isSuccess = false,
                    errors = result.validation_errors
                }) : BadRequest(),
                401 => Unauthorized(),
                403 => Forbid(),
                404 => NotFound(),
                409 => Conflict(),
                204 => NoContent(),
                500 => StatusCode(500, "Internal Server Error"),
                _ => BadRequest()
            };

        }

    }
}
