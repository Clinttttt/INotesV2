using INotesV2.Application.Dtos.Tag;
using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Queries.Tag.GetListingTag
{
    public class GetListingTagQueryHandler(ITagRespository respository) : IRequestHandler<GetListingTagQuery, Result<List<TagDto>>>
    {
        public async Task<Result<List<TagDto>>> Handle(GetListingTagQuery request, CancellationToken cancellationToken)
        {
           return await respository.GetListing(request.user_id,cancellationToken);
        }
    }
}
