using System.Threading;
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
            return View(repository.Medias);
        }

        [HttpPost]
        public JsonResult InsertMedia(string url)
        {           
            Thread.Sleep(5000);
            if(url != string.Empty)
            {
                // TODO: Validação da Media
                var media = new Media { Band = url, Url = url, Song = url };

                repository.SaveMedia(media);                
            }
            
            return Json(repository.Medias);
        }

        [HttpPost]
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
