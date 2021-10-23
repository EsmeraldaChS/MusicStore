using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Domain
{
    public class Song
    {
        public int SongId { get; set; }

        public int AlbumId { get; set; }

        public string NameSong { get; set; }

        public TimeSpan Duration { get; set; }

        public Album Album { get; set; } // propiedad virtual, fuera de la estructura creada para relacionar con el Album y traer los datos, es como el FK
    }
}
