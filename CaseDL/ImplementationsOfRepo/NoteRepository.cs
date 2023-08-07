using CaseDL.InterfacesOfRepo;
using CaseEL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDL.ImplementationsOfRepo
{
    public class NoteRepository : Repository<Note, int>, INoteRepository
    {
        public NoteRepository(NoteContext context) : base(context)
        {
        }
    }
}
