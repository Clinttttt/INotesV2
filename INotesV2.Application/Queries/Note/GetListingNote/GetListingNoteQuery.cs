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
    public record GetListingNoteQuery(Guid user_id, DateTime? Cursor, int PageSize = 20) : IRequest<Result<CursorPagedResult<NoteListDto>>>;
  
}
