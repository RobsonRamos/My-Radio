using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyRadio.Domain.Repositories;
using MyRadio.Models;

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
            var medias = new List<Media>();
            
            medias.AddRange(new[]{ 
                new Media{Band = "Iron Maiden", Song = "Fear of the Dark"},
                new Media{Band = "Pink Floyd", Song = "The dark side of the moon"},
                new Media{Band = "Metallica", Song = "Seek and Destroy"},
                new Media{Band = "Led Zeppelin", Song = "Starway to Heaven"},
                new Media{Band = "Deep Purple", Song = "Smoke on the Water"},
            });
            
            return View(medias);
        }
        public JsonResult InsertMedia(string url)
        {            
            return Json("Complete",JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddMedia(Media media)
        {
            if(ModelState.IsValid)
            {
                repository.SaveMedia(media);                
            }
            return Json(repository.Medias);
        }
    }
}
