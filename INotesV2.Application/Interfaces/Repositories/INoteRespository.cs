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
        Task<Result<NoteDto>> Get(Guid note_id, Guid user_id, CancellationToken cancellationToken = default);
        Task<CursorPagedResult<NoteDto>> GetListing(Guid userId, DateTime? cursor, int pageSize, CancellationToken cancellationToken = default);
        Task<Result<bool>> Delete(Guid note_id, Guid user_id, CancellationToken cancellationToken = default);
    }
}
