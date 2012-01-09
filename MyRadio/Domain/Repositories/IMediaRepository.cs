using System.Linq;
using MyRadio.Models;

namespace MyRadio.Domain.Repositories
{
    public interface IMediaRepository
    {
        IQueryable<Media> Medias { get; }

        void SaveMedia(Media media);
    }
}