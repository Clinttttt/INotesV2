using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Queries.Note.GetNote
{
    public class GetNoteQueryHandler(INoteRespository respository) : IRequestHandler<GetNoteQuery, Result<NoteDto>>
    {
        public async Task<Result<NoteDto>> Handle(GetNoteQuery request, CancellationToken cancellationToken)
        {
            return await respository.Get(request.note_id,request.user_id, cancellationToken);
        }
    }

}
