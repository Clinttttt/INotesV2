using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Models
{
    public class CursorQueryParams
    {
        public DateTime? Cursor { get; init; }
        public int PageSize { get; init; } = 20;
    }
}
