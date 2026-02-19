using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string? name { get; set; }
    }
}
