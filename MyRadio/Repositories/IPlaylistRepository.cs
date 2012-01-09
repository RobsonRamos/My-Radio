using System.Linq;
using MyRadio.Models;

namespace MyRadio.Repositories
{
    public interface IPlaylistRepository
    {
        IQueryable<Playlist> Playlists { get; }
        
    }
}
