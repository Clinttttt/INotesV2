using INotesV2.Application.Commands.Tag.AddTagToNote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Requests.Tag
{
    public class AddTagToNoteRequest
    {
        public Guid tag_id { get; set; }
        public Guid note_id { get; set; }
        public AddTagToNoteCommand AddTagToNoteCommand(Guid user_id) => new( note_id,tag_id, user_id);
    }
}
