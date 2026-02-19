using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Dtos.Note
{
    public class CreateNoteDto
    {
        public Guid? user_id { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
    }
}
