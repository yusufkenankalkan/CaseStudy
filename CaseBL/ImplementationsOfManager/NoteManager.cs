using AutoMapper;
using CaseBL.InterfacesOfManager;
using CaseDL.InterfacesOfRepo;
using CaseEL.Models;
using CaseEL.ResultModels;
using CaseEL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseBL.ImplementationsOfManager
{
    public class NoteManager : Manager<NoteVM, Note, int>, INoteManager
    {
        public NoteManager(INoteRepository repo, IMapper mapper) : base(repo, mapper, null)
        {

        }

    }
}
