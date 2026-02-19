using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Interfaces.Repositories;
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
    public class GetListingNoteQueryhandler(INoteRespository respository) : IRequestHandler<GetListingNoteQuery, Result<CursorPagedResult<NoteListDto>>>
    {
        public Task<Result<CursorPagedResult<NoteListDto>>> Handle(GetListingNoteQuery request, CancellationToken cancellationToken)
        {
            var dto = new CursorQueryParams { Cursor = request.Cursor, PageSize = request.PageSize };
            return respository.GetListing(request.user_id, dto);
        }
    }
}
