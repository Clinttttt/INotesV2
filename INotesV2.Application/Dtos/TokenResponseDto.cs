using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Dtos
{
    public class TokenResponseDto
    {
        public string? access_token { get; set; } 
        public string? refresh_token { get; set; }
    }
}
