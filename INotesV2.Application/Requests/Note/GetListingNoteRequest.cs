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
        public DateTime? Cursor { get; init; }
        public int PageSize { get; init; } = 20;

        public GetListingNoteQuery GetListingNoteQuery(Guid user_id) => new(user_id, Cursor, PageSize);
       
    }
}
