using AutoMapper;
using CaseEL.Models;
using CaseEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseEL.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            //Automapper ile modellerimiz ile vmlerimizi birleştirdik.
            CreateMap<Note, NoteVM>().ReverseMap();
        }
    }
}
