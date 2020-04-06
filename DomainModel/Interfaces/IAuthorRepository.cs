using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.Interfaces
{
    public interface IAuthorRepository
    {
        void Create(Author author);
        Author Delete(int Id);
        Author GetbyId(int id);
        List<Author> GetList();

        List<Album> GetAuthorAlbums(int authorId, int page, int pagesize);

        int CalculatePages(int authorid, int pagesize);
    }
}