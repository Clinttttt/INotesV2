using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Models
{
    public class CursorPagedResult<T>
    {
        public List<T> Items { get; init; } = [];
        public DateTime? NextCursor { get; init; } 
        public bool HasMore { get; init; }
    }
}
