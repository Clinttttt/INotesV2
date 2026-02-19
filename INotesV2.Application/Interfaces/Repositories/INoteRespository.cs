using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Models;
using INotesV2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Interfaces.Repositories
{
    public interface INoteRespository
    {
        Task<Result<Guid>> Create(CreateNoteDto request, CancellationToken cancellationToken = default);
        Task<Result<UpdateNoteDto>> Update(UpdateNoteDto request, CancellationToken cancellationToken = default);
        Task<Result<NoteDto>> Get(Guid note_id, CancellationToken cancellationToken = default);
        Task<Result<CursorPagedResult<NoteListDto>>> GetListing(Guid user_id, CursorQueryParams params_query, CancellationToken cancellationToken = default);
        Task<Result<bool>> Delete(Guid note_id, CancellationToken cancellationToken = default);
    }
}
