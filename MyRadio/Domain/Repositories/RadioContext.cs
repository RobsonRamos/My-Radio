﻿using System.Data.Entity;
using MyRadio.Models;

namespace MyRadio.Domain.Repositories
{
    public class RadioContext : DbContext 
    {
        public DbSet<Media> Medias { get; set; }

        public DbSet<Playlist> Playlists { get; set; } 

    }
}