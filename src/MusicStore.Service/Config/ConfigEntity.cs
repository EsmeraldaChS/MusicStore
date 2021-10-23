using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicStore.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Service.Config
{
    public class AlbumConfig
    {
        public AlbumConfig(EntityTypeBuilder<Album> entityTypeBuilder ) // Permite moldear las clases , entityTypeBuilder : Variable
        {
            //entityTypeBuilder.Property(e => e.AlbumId).HasKey
            entityTypeBuilder.Property(e => e.NameAlbum).HasColumnType("varchar (350)").IsRequired(); //IsRequired: Not null
            entityTypeBuilder.Property(e => e.Artist).HasColumnType("varchar (350)").IsRequired();
            entityTypeBuilder.Property(e => e.AlbumCover).HasColumnType("varchar (350)").IsRequired();
            entityTypeBuilder.HasMany(e => e.Songs).WithOne(e => e.Album).HasForeignKey(e => e.AlbumId).IsRequired();//relación de 1 a muchos
        }
    }

    public class SongConfig
    {
        public SongConfig(EntityTypeBuilder<Song> entityTypeBuilder)
        {
            // Falta el SongId, esto se genera sólo simepre y cuando hay un Id al final o principio.
            entityTypeBuilder.Property(e => e.AlbumId).HasColumnType("int").IsRequired();
            entityTypeBuilder.Property(e => e.NameSong).HasColumnType("varchar (350)").IsRequired();
            
        }
    }

    public class UserConfig
    {
        public UserConfig(EntityTypeBuilder<User> entityTypeBuilder)
        {
            entityTypeBuilder.Property(e => e.NameUser).HasColumnType("varchar (350)").IsRequired();
            entityTypeBuilder.Property(e => e.PassUser).HasColumnType("varchar (350)").IsRequired();
            
        }

    }

}
