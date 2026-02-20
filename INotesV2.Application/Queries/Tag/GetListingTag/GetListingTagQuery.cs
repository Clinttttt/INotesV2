using INotesV2.Application.Dtos.Tag;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Queries.Tag.GetListingTag
{
    public record GetListingTagQuery(Guid user_id) : IRequest<Result<List<TagDto>>>;
   
}
