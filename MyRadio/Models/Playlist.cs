using System.Collections.Generic;
using System.Linq;

namespace MyRadio.Models
{
    public class Playlist
    {
        public int PlaylistId { get; set; } 
        public IList<Media> Medias { get; set; } 
    }
}