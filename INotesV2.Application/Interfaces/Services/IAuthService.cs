using INotesV2.Application.Dtos;
using INotesV2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<Result<TokenResponseDto>> GoogleLogin(string id_token, CancellationToken cancellationToken = default);
    }
}
