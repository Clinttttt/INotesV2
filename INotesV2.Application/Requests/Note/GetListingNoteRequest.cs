using INotesV2.Application.Queries.Note.GetListingNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Requests.Note
{
    public class GetListingNoteRequest
    {
        public DateTime? Cursor { get; set; }
        public int PageSize { get; set; } = 20;

        public GetListingNoteQuery GetListingNoteQuery(Guid userId) => new()
        {
            UserId = userId,
            Cursor = Cursor,
            PageSize = PageSize
        };
    }
}
