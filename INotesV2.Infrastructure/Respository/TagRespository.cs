using AutoMapper;
using INotesV2.Application.Dtos.Tag;
using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Domain.Common;
using INotesV2.Domain.Entities;
using INotesV2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Infrastructure.Respository
{
    public class TagRespository(IAppDbContext context, IMapper mapper) : ITagRespository
    {
        public async Task<Result<Guid>> Create(CreateTagDto request, CancellationToken cancellationToken = default)
        {
            var find_user = await context.users.FirstOrDefaultAsync(s => s.Id == request.user_id, cancellationToken);
            if (find_user is null) return Result<Guid>.NotFound();

            var tag = new Tag
            {
                user_id = request.user_id,
                name = request.name,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow
            };
            context.tags.Add(tag);
            await context.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(tag.Id);
        }
        public async Task<Result<bool>> Delete(Guid user_id, Guid tag_id, CancellationToken cancellationToken = default)
        {
            var find_tag = await context.tags.FirstOrDefaultAsync(s => s.Id == tag_id && s.user_id == user_id, cancellationToken);
            if (find_tag is null) return Result<bool>.NotFound();

            context.tags.Remove(find_tag);
            await context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);

        }
       public async Task<Result<List<TagDto>>> GetListing(Guid user_id, CancellationToken cancellationToken = default)
        {
            var tags = await context.tags.Where(s => s.user_id == user_id).ToListAsync(cancellationToken);
            var dto = mapper.Map<List<TagDto>>(tags);
            return Result<List<TagDto>>.Success(dto);
        }
        public async Task<Result<bool>> AddTagToNote(Guid note_id, Guid tag_id, Guid user_id, CancellationToken cancellationToken = default)
        {
            var find_note = await context.notes.FirstOrDefaultAsync(s => s.Id == note_id && s.user_id == user_id, cancellationToken);
            if (find_note is null) return Result<bool>.NotFound();
            var find_tag = await context.tags.FirstOrDefaultAsync(s => s.Id == tag_id && s.user_id == user_id, cancellationToken);
            if (find_tag is null) return Result<bool>.NotFound();
            var note_tag = new NoteTag
            {
                note_id = note_id,
                tag_id = tag_id
            };
            context.noteTags.Add(note_tag);
            await context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);
        }
    }
}
