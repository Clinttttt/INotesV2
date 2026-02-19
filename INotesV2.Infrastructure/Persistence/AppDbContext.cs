using INotesV2.Domain.Entities;
using INotesV2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Infrastructure.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Note> notes { get; set; }
        public DbSet<NoteTag> noteTags { get; set; }    
        public DbSet<User> users { get; set; }  
        public DbSet<Tag> tags { get; set; }    
    }
}
