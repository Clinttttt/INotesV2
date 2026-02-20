using INotesV2.Domain.Common;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Tag.CreateTag
{
    public record CreateTagCommand(Guid user_id, string name) : IRequest<Result<Guid>>;
    
}
