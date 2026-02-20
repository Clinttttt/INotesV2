using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Models;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Queries.Note.GetListingNote
{
    public class GetListingNoteQuery : IRequest<Result<CursorPagedResult<NoteDto>>>
    {
        public Guid UserId { get; set; }
        public DateTime? Cursor { get; set; }
        public int PageSize { get; set; } = 20;
    }

}
