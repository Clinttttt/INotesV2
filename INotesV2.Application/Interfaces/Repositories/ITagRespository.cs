using INotesV2.Application.Dtos.Tag;
using INotesV2.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application.Interfaces.Repositories
{
    public interface ITagRespository
    {
        Task<Result<Guid>> Create(CreateTagDto request, CancellationToken cancellationToken = default);
        Task<Result<bool>> Delete(Guid user_id, Guid tag_id, CancellationToken cancellationToken = default);
        Task<Result<List<TagDto>>> GetListing(Guid user_id, CancellationToken cancellationToken = default);
        Task<Result<bool>> AddTagToNote(Guid note_id, Guid tag_id, Guid user_id, CancellationToken cancellationToken = default);
    }
}
