using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Dtos.Note
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public Guid? user_id { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
        public bool is_pinned { get; set; }
        public bool is_archived { get; set; }
        public DateTime created_at { get; set; }
    }
}
