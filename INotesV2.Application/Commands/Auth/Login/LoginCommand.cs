using INotesV2.Application.Dtos;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Auth.Login
{
    public record LoginCommand(string id_token) : IRequest<Result<TokenResponseDto>>;
    
}
