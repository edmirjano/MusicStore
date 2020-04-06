using DomainModel.DbContext;
using DomainModel.Interfaces;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        public void Create(Author author)
        {
            if (author.AuthorId == 0)
            {
                _context.Authors.Add(author);
            }
            else
            {
                Author dbEntry = _context.Authors.Find(author.AuthorId);
                if (dbEntry != null)
                {
                    dbEntry.Name = author.Name;
                    dbEntry.Age = author.Age;

                    _context.SaveChanges();
                }
            }
            _context.SaveChanges();
        }
        public Author GetbyId(int id)
        {
            return _context.Authors.Find(id);
        }

        public Author Delete(int Id)
        {
            Author dbEntry = _context.Authors.Find(Id);
            if (dbEntry != null)
            {
                _context.Authors.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public List<Author> GetList()
        {
            return _context.Authors.ToList();
        }
        public List<Album> GetAuthorAlbums(int authorId, int page, int pagesize)
        {
            return _context.Albums.Where(x => x.AuthorId == authorId).OrderBy(x => x.AlbumId).Skip((page - 1) * pagesize).Take(pagesize).ToList();
        }
        public int NrOfAlbums(int AuthorId)
        {
            return _context.Albums.Where(x => x.AuthorId == AuthorId).Count();
        }
        public int CalculateDecimal(int NrOfAlbums, int pagesize)
        {
            int pages = new int();
            decimal x = (decimal)NrOfAlbums / (decimal)pagesize;
            var y = Math.Round(x, MidpointRounding.AwayFromZero);
            if (y == (int)NrOfAlbums / pagesize)
            {
                pages = NrOfAlbums / pagesize;
            }
            else
            {
                pages = NrOfAlbums / pagesize + 1;
            }
            return pages;
        }
        public int CalculatePages(int authorid, int pagesize)
        {


            var NrOfAlbums = this.NrOfAlbums(authorid);


            return this.CalculateDecimal(NrOfAlbums, pagesize);
        }

    }
}
