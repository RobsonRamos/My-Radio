using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRadio.Models;
using MyRadio.Repositories;

namespace MyRadio.Controllers
{
    public class RadioController : Controller
    {
        private IMediaRepository repository;

        public RadioController(IMediaRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult Index()
        {
            return View(repository.Medias);
        }

        public ViewResult Edit(int mediaId = 0)
        {
            var media = repository.Medias.FirstOrDefault(m => m.MediaId == mediaId);
            return View(media);
        }

        [HttpPost]
        public ActionResult Edit(Media media)
        {
            if(ModelState.IsValid)
            {
                repository.SaveMedia(media);
                return RedirectToAction("Index");
            }
            return View(media);
        }
    }
}
