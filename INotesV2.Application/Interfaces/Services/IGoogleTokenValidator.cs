using INotesV2.Application.Models;
using INotesV2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Interfaces.Services
{
    public interface IGoogleTokenValidator
    {
        Task<Result<GoogleUserInfo>> ValidateAsync(string id_token);
    }
}
