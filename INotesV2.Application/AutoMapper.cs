using AutoMapper;
using INotesV2.Application.Dtos.Note;
using INotesV2.Application.Dtos.Tag;
using INotesV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INotesV2.Application
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Note, NoteDto>();
            CreateMap<Note, UpdateNoteDto>();
            CreateMap<Tag, TagDto>();
        }
    }
}
