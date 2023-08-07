using CaseBL.InterfacesOfManager;
using CaseDL;
using CaseEL.Models;
using CaseEL.ResultModels;
using CaseEL.ViewModels;
using CaseUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;

namespace CaseUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteManager _noteManager;

        public HomeController(INoteManager noteManager)
        {
            _noteManager = noteManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            string url = "http://localhost:5053/n/allnotes";

            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                string resultJSON = client.DownloadString(url);
                var data = JsonConvert.DeserializeObject<List<NoteVM>>(resultJSON);

                ViewBag.Result = data;
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(NoteVM model)
        {

            if (!ModelState.IsValid)
            {
                string url = "http://localhost:5053/n/sendernotes";

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    string jsonData = JsonConvert.SerializeObject(model);
                    string resultJSON = client.UploadString(url, "POST", jsonData);

                    if (resultJSON == "Not başarıyla eklendi.")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Not kaydedilirken bir hata oluştu.");
                    }
                }
            }

            string urlGet = "http://localhost:5053/n/allnotes";
            using (WebClient client = new WebClient())
            {
                client.Headers.Add(HttpRequestHeader.Accept, "application/json");
                string resultJSON = client.DownloadString(urlGet);
                var data = JsonConvert.DeserializeObject<List<NoteVM>>(resultJSON);

                ViewBag.Result = data;
            }

            return View(model);
        }

        [HttpPost]       
        public IActionResult DeleteNote(int id)
        {
            var note = _noteManager.GetByConditions(x => x.Id == id).Data;
            if (note != null)
            {
                note.IsDeleted = true;
                _noteManager.Update(note);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}