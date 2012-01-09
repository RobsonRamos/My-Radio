using System.Linq;
using MyRadio.Models;

namespace MyRadio.Domain.Repositories
{
    public interface IPlaylistRepository
    {
        IQueryable<Playlist> Playlists { get; }
        
    }
}
