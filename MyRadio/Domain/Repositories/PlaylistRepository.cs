using System.Linq;
using MyRadio.Models;

namespace MyRadio.Domain.Repositories
{
    public class PlaylistRepository : IPlaylistRepository
    {
        private RadioContext context = new RadioContext(); 

        public IQueryable<Playlist> Playlists
        {
            get { return context.Playlists; }
        }

       
    }
}