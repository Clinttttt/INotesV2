using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Tag.DeleteTag
{
    public class DeleteTagCommandHandler(ITagRespository respository) : IRequestHandler<DeleteTagCommand, Result<bool>>
    {
        public  async Task<Result<bool>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
        {
            return await respository.Delete(request.user_id, request.tag_id,cancellationToken);
        }
    }
}
