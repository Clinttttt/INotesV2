using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Tag.AddTagToNote
{
    public class AddTagToNoteCommandHandler(ITagRespository respository) : IRequestHandler<AddTagToNoteCommand, Result<bool>>
    {
        public async Task<Result<bool>> Handle(AddTagToNoteCommand request, CancellationToken cancellationToken)
        {
            return await respository.AddTagToNote(request.note_id, request.tag_id, request.user_id,cancellationToken);          
        }
    }
}
