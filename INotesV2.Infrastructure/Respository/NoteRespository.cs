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
    public class NoteRespository(IAppDbContext context) : INoteRespository
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
            var find_note = await context.notes.FirstOrDefaultAsync(s => s.Id == request.note_id);
            if (find_note is null) return Result<UpdateNoteDto>.NotFound();

            find_note.title = request.title;
            find_note.content = request.content;
            find_note.updated_at = DateTime.UtcNow;

            await context.SaveChangesAsync(cancellationToken);
            return Result<UpdateNoteDto>.Success(request);
        }
        public async Task<Result<NoteDto>> Get(Guid note_id, CancellationToken cancellationToken = default)
        {
            var find_note = await context.notes.AsNoTracking().FirstOrDefaultAsync(s => s.Id == note_id, cancellationToken);
            if (find_note is null) return Result<NoteDto>.NotFound();
            var note_dto = new NoteDto
            {
                Id = find_note.Id,
                user_id = find_note.user_id,
                title = find_note.title,
                content = find_note.content,
                created_at = find_note.created_at,
                is_archived = find_note.is_archived,
                is_pinned = find_note.is_pinned
            };
            return Result<NoteDto>.Success(note_dto);
        }
        public async Task<Result<CursorPagedResult<NoteListDto>>> GetListing(Guid user_id, CursorQueryParams params_query, CancellationToken cancellationToken = default)
        {

            var query = context.notes.AsNoTracking().Where(s => s.user_id == user_id);

            if (params_query.Cursor.HasValue)
            {
                query = query.Where(s => s.created_at < params_query.Cursor.Value);
            }

            var result = await query.OrderByDescending(s => s.created_at)
                .Take(params_query.PageSize)
                .Select(s => new NoteListDto
                {
                    note_id = s.Id,
                    user_id = s.user_id,
                    title = s.title,
                    content = s.content
                })
                .ToCursorPagedResult(params_query.PageSize, s => s.created_at, cancellationToken);
            return Result<CursorPagedResult<NoteListDto>>.Success(result);
        }

        public async Task<Result<bool>> Delete(Guid note_id, CancellationToken cancellationToken = default)
        {
            var find_note = await context.notes.FirstOrDefaultAsync(s => s.Id == note_id);
            if (find_note is null) return Result<bool>.NotFound();
            context.notes.Remove(find_note);
            await context.SaveChangesAsync(cancellationToken);
            return Result<bool>.Success(true);

        }
    }
}