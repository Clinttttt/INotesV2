using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Tag.AddTagToNote
{
    public record AddTagToNoteCommand(Guid note_id, Guid tag_id, Guid user_id) : IRequest<Result<bool>>;
   
}
