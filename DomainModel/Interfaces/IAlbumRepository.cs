using DomainModel.Models;
using System.Collections.Generic;
using System.Web;

namespace DomainModel.Interfaces
{
    public interface IAlbumRepository
    {
        List<Album> AlbumsOnSale();
        void Create(Album album);
        Album Delete(int albumId);
        List<Album> GetByAuthor(int id);
        List<Album> GetByCategory(int id);
        List<Album> GetByCategory(int id, int page, int pagesize);
        Album GetbyId(int id);
        List<Album> GetRelated(int id);
        List<Album> GetList();
        List<Album> GetList(int pageNr = 1, int pageSize = 3);
        List<Album> SearchByTitle(string title, int page, int pagesize);
        int NrOfAlbums();
        int NrOfAlbums(int categoryid);
        int CalculatePages(int categoryid, int pagesize);
        int CalculatePagesForSearch(string title, int pagesize);
    }
}