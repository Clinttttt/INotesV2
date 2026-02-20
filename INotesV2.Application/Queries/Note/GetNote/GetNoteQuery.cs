using INotesV2.Application.Dtos.Note;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Queries.Note.GetNote
{
    public record GetNoteQuery(Guid user_id, Guid note_id) : IRequest<Result<NoteDto>>;
    
}
