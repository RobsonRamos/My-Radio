using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRadio.Models;

namespace MyRadio.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private RadioContext context = new RadioContext();

        public IQueryable<Media> Medias
        {
            get { return context.Medias; }
        }

        public void SaveMedia(Media media)
        {
            if(media.MediaId == 0)
            {
                context.Medias.Add(media);
            }

            context.SaveChanges();
        }
    }
}