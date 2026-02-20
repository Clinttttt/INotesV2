using INotesV2.Application.Commands.Tag.CreateTag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Requests.Tag
{
    public class CreateTagRequest
    {
        public string? name { get; set; }
        public CreateTagCommand CreateTagCommand(Guid user_id) => new(user_id, name!);
    }
}
