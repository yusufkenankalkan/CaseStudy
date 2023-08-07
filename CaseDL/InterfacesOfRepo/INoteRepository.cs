using CaseEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseDL.InterfacesOfRepo
{
    public interface INoteRepository : IRepository<Note, int>
    {
    }
}
