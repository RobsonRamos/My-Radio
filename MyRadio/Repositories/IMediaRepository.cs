using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyRadio.Models;

namespace MyRadio.Repositories
{
    public interface IMediaRepository
    {
        IQueryable<Media> Medias { get; }

        void SaveMedia(Media media);
    }
}