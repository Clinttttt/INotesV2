using INotesV2.Application.Dtos;
using INotesV2.Domain.Common;
using INotesV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Interfaces.Services
{
    public interface ITokenService
    {
        Task<User> ValidateRefreshToken(Guid UserId, string refresh_Token, CancellationToken cancellationToken = default);
        Task<Result<TokenResponseDto>> CreateTokenResponse(User user, CancellationToken cancellationToken = default);
    }
}
