using INotesV2.Application.Dtos;
using INotesV2.Application.Interfaces.Services;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Auth.Login
{
    public class LoginCommandHandler(IAuthService auth_service) : IRequestHandler<LoginCommand, Result<TokenResponseDto>>
    {
        public async Task<Result<TokenResponseDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await auth_service.GoogleLogin(request.id_token);
        }
    }
}
