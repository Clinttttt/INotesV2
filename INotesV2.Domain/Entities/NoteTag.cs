using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Domain.Entities
{
    public class NoteTag
    {
        public Guid Id { get; set; }
        public Guid user_id { get; set; }
        public Guid tag_id { get; set; }
        public Guid note_id { get; set; }

    }
}
