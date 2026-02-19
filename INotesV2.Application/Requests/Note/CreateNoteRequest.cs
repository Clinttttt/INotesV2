using INotesV2.Application.Commands.Note.CreateNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Requests.Note
{
    public class CreateNoteRequest
    {
        public string? title { get; set; }
        public string? content { get; set; }
        public CreateNoteCommand createNoteCommand(Guid? user_id) => new (user_id, title, content);
    }
}
