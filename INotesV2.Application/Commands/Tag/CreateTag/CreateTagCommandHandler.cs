using INotesV2.Application.Dtos.Tag;
using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Tag.CreateTag
{
    public class CreateTagCommandHandler(ITagRespository respository) : IRequestHandler<CreateTagCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
        {
            var dto = new CreateTagDto { user_id = request.user_id, name = request.name };
            return await respository.Create(dto,cancellationToken);
        }
    }
}
