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
    public class GetListingNoteQueryHandler(INoteRespository repository)
    : IRequestHandler<GetListingNoteQuery, Result<CursorPagedResult<NoteDto>>>
    {
        public async Task<Result<CursorPagedResult<NoteDto>>> Handle(
            GetListingNoteQuery request, CancellationToken cancellationToken)
        {
            var result = await repository.GetListing(request.UserId, request.Cursor, request.PageSize, cancellationToken);
            return Result<CursorPagedResult<NoteDto>>.Success(result);
        }
    }
}