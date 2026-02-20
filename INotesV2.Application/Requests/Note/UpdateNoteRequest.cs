using INotesV2.Application.Commands.Note.UpdateNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Requests.Note
{
    public class UpdateNoteRequest
    {
        public string? title { get; set; }
        public string? content { get; set; }
        public UpdateNoteCommand UpdateNoteCommand(Guid user_id,Guid id) => new (user_id, id, title, content); 
    }
}
