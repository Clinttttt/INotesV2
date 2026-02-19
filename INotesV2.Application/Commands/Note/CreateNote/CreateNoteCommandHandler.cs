using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Commands.Note.CreateNote
{
    public class CreateNoteCommandHandler(INoteRespository respository) : IRequestHandler<CreateNoteCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var dto = new CreateNoteDto
            {
                title = request.title,
                content = request.content,
                user_id = request.user_id
            };
            var command = await respository.Create(dto,cancellationToken);
            return command;
        }
    }
}
