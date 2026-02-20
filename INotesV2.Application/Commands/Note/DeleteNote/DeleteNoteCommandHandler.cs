using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Note.DeleteNote
{
    public class DeleteNoteCommandHandler(INoteRespository respository) : IRequestHandler<DeleteNoteCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            return await respository.Delete(request.note_id, request.user_id,cancellationToken);
        }
    }
}
