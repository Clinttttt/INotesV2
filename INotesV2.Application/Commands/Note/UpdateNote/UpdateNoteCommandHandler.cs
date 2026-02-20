using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Note.UpdateNote
{
    public class UpdateNoteCommandHandler(INoteRespository respository) : IRequestHandler<UpdateNoteCommand, Result<UpdateNoteDto>>
    {
        public async Task<Result<UpdateNoteDto>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var dto = new UpdateNoteDto { title = request.title, content = request.content, note_id = request.note_id, user_id = request.user_id };
            return await respository.Update(dto, cancellationToken);
        }
    }
}
