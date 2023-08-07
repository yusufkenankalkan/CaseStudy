using CaseBL.InterfacesOfManager;
using CaseEL.Models;
using CaseEL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CaseAPI.Controllers
{
    [ApiController]
    [Route("n")]
    public class NoteController : Controller
    {
        private readonly INoteManager _noteManager;

        public NoteController(INoteManager noteManager)
        {
            _noteManager = noteManager;
        }


        [HttpGet]
        [Route("allnotes")]
        public IActionResult Index()
        {
            var data = _noteManager.GetAll(x => x.ParentId == null && !x.IsDeleted).Data;
            foreach (var note in data)
            {
                if (note.ParentId == null)
                {
                    note.Children = GetAllChildNotes(note.Id);
                }
            }
            ViewBag.Result = data;
            return Ok(data);
        }

        private List<NoteVM> GetAllChildNotes(int parentId)
        {
            var childNotes = _noteManager.GetAll(x => x.ParentId == parentId && !x.IsDeleted).Data.ToList();
            foreach (var childNote in childNotes)
            {
                childNote.Children = GetAllChildNotes(childNote.Id);
            }
            return childNotes;
        }



        [HttpPost]
        [Route("sendernotes")]
        public IActionResult SenderNotes(NoteVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Geçersiz model. Not eklenemedi.");
                }

                NoteVM note = new NoteVM
                {
                    Content = model.Content,
                    ParentId = model.ParentId,                 
                };

                var result = _noteManager.Add(note);

                if (result.IsSuccess)
                    return Created("", "Not başarıyla eklendi.");
                else
                    return BadRequest("Not eklenemedi.");

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
