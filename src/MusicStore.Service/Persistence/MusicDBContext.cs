using Microsoft.EntityFrameworkCore;
using MusicStore.Domain;
using MusicStore.Service.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Service.Persistence
{
    public class MusicDBContext: DbContext // hereda de DBContext
    {
        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Album { get; set; }

        public DbSet<User> Users { get; set; }

        public MusicDBContext(DbContextOptions<MusicDBContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Agregar las configuraciones del ConfigEntity
        {
            new AlbumConfig(modelBuilder.Entity<Album>());
            new SongConfig(modelBuilder.Entity<Song>());
            new UserConfig(modelBuilder.Entity<User>());
        }
    }
}
