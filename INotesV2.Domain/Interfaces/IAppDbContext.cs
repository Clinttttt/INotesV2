using INotesV2.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Domain.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Category> categories { get; set; }
        DbSet<Note> notes { get; set; }
        DbSet<NoteTag> noteTags { get; set; }
        DbSet<User> users { get; set; }
        DbSet<Tag> tags { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
