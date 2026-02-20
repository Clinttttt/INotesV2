using AutoMapper;
using AutoMapper.QueryableExtensions;
using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Extensions;
using INotesV2.Application.Interfaces.Repositories;
using INotesV2.Application.Models;
using INotesV2.Domain.Common;
using INotesV2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace INotesV2.Infrastructure.Respository
{
    public class NoteRespository(IAppDbContext context, IMapper mapper) : INoteRespository
    {


        public async Task<Result<Guid>> Create(CreateNoteDto request, CancellationToken cancellationToken = default)
        {
            var note = new Domain.Entities.Note
            {
                user_id = request.user_id,
                title = request.title,
                content = request.content,
                created_at = DateTime.UtcNow,
                updated_at = DateTime.UtcNow,
                is_archived = false,
                is_pinned = false
            };
            context.notes.Add(note);
            await context.SaveChangesAsync(cancellationToken);
            return Result<Guid>.Success(note.Id);
        }

        public async Task<Result<UpdateNoteDto>> Update(UpdateNoteDto request, CancellationToken cancellationToken = default)
        {
            var find_note = await context.notes.FirstOrDefaultAsync(s => s.Id == request.note_id && s.user_id == request.user_id);
            if (find_note is null) return Result<UpdateNoteDto>.NotFound();

            find_note.title = request.title;
            find_note.content = request.content;
            find_note.updated_at = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);
            var dto = mapper.Map<UpdateNoteDto>(find_note);
            return Result<UpdateNoteDto>.Success(dto);
        }
        public async Task<Result<NoteDto>> Get(Guid note_id,Guid user_id, CancellationToken cancellationToken = default)
        {
            var find_note = await context.notes.AsNoTracking().FirstOrDefaultAsync(s => s.Id == note_id && s.user_id == user_id, cancellationToken);
            if (find_note is null) return Result<NoteDto>.NotFound();
            var note_dto = mapper.Map<NoteDto>(find_note);
            return Result<NoteDto>.Success(note_dto);
        }
        public async Task<CursorPagedResult<NoteDto>> GetListing(Guid userId, DateTime? cursor, int pageSize, CancellationToken cancellationToken = default)
        {
            var query = context.notes.Where(n => n.user_id == userId && !n.is_archived).OrderBy(n => n.created_at).AsQueryable();
            if (cursor.HasValue) query = query.Where(n => n.created_at > cursor.Value);
            var queryDto = query.ProjectTo<NoteDto>(mapper.ConfigurationProvider);
            return await queryDto.ToCursorPagedResult(pageSize, n => n.created_at, cancellationToken);
        }

        public async Task<Result<bool>> Delete(Guid note_id, Guid user_id, CancellationToken cancellationToken = default)
        {
            var find_note = await context.notes.FirstOrDefaultAsync(s => s.Id == note_id && s.user_id == user_id);
            if (find_note is null) return Result<bool>.NoContent();
            context.notes.Remove(find_note);
            await context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);

        }
    }
}
