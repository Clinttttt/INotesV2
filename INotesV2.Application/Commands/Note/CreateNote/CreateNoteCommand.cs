using INotesV2.Application.Dtos.Note;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Note.CreateNote
{
    public record CreateNoteCommand(Guid? user_id, string? title, string? content) : IRequest<Result<Guid>>;

}
