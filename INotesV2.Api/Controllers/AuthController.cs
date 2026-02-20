using FluentValidation;
using INotesV2.Api.Shared;
using INotesV2.Application.Commands.Auth.Login;
using INotesV2.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace INotesV2.Api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ApiBaseController
    {
        public AuthController(ISender sender) : base(sender) { }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login([FromBody] INotesV2.Application.Commands.Auth.Login.LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await sender.Send(request, cancellationToken);
            return HandleResponse(result);

        }
    }
}
