using System;
using System.Collections.Generic;

namespace MusicStore.Domain
{
    public class Album
    {
        public int AlbumId { get; set; }

        public string NameAlbum { get; set; }

        public string Artist { get; set; }

        public string AlbumCover { get; set; }

        public List<Song> Songs { get; set; } // lista con nombre Songs
    }
}
