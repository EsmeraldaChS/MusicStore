using Microsoft.EntityFrameworkCore;
using MusicStore.Domain;
using MusicStore.Service.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Service.Services
{
    public interface IAlbumService // Sirve para la inyecciones de dependencia
    {
        //Agregar métodos asincronos, ejecutados al mismo tiempo
        Task SaveAlbum(Album album);
        Task<List<Album>> ListAlbum(); // función y retorna la lista de albumes


    }
    public class AlbumService: IAlbumService // Inyecciones
    {
        private readonly MusicDBContext _musicDBContext;
        
        public AlbumService(MusicDBContext musicDBContext)
        {
            _musicDBContext = musicDBContext;
        }

        public async Task<List<Album>> ListAlbum()
        {
            try
            {
                return await _musicDBContext.Album.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            };
        }

        public async Task SaveAlbum(Album album)
        {
            try
            {
                await _musicDBContext.Album.AddAsync(album);
                await _musicDBContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
