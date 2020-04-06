using DomainModel.DbContext;
using DomainModel.Interfaces;
using DomainModel.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        public void Create(Album album)
        {
            if (album.AlbumId == 0)
            {
                _context.Albums.Add(album);
            }
            else
            {
                Album dbEntry = _context.Albums.Find(album.AlbumId);
                if (dbEntry != null)
                {
                    dbEntry.Name = album.Name;
                    dbEntry.AuthorId = album.AuthorId;
                    dbEntry.Price = album.Price;
                    dbEntry.CategoryId = album.CategoryId;
                    dbEntry.NrOfSongs = album.NrOfSongs;
                    dbEntry.OnSale = album.OnSale;
                    dbEntry.Year = album.Year;
                    dbEntry.ImagePath = album.ImagePath;

                    _context.SaveChanges();
                }
            }
            _context.SaveChanges();
        }
        public Album GetbyId(int id)
        {
            return _context.Albums.Find(id);
        }

        public Album Delete(int albumId)
        {
            Album dbEntry = _context.Albums.Find(albumId);
            if (dbEntry != null)
            {
                _context.Albums.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public List<Album> GetList()
        {
            return _context.Albums.ToList();
        }
        public List<Album> GetList(int pageNr = 1, int pageSize = 3)
        {
            return _context.Albums.OrderBy(x => x.AlbumId).Skip((pageNr - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Album> GetRelated(int id)
        {
            return _context.Albums.Where(x => x.CategoryId == id).Take(3).ToList();
        }
        public List<Album> GetByCategory(int id)
        {
            return _context.Albums.Where(x => x.CategoryId == id).ToList();
        }
        public List<Album> GetByCategory(int id, int pageNr = 1, int pageSize = 3)
        {
            return _context.Albums.Where(x => x.CategoryId == id).OrderBy(x => x.AlbumId).Skip((pageNr - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Album> GetByAuthor(int id)
        {
            return _context.Albums.Where(x => x.AuthorId == id).ToList();
        }

        public List<Album> SearchByTitle(string title, int pageNr = 1, int pageSize = 3)
        {
            return _context.Albums.Where(x => x.Name.Contains(title)).OrderBy(x => x.AlbumId).Skip((pageNr - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Album> AlbumsOnSale()
        {
            return _context.Albums.Where(x => x.OnSale == true).ToList();
        }
        public int NrOfAlbums()
        {
            return _context.Albums.Count();
        }

        public int NrOfAlbums(int categoryid)
        {
            return _context.Albums.Where(x => x.CategoryId == categoryid).Count();
        }
        public int NrOfAlbums(string title)
        {
            return _context.Albums.Where(x => x.Name.Contains(title)).Count();
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
        public int CalculatePages(int categoryid = 0, int pagesize = 3)
        {
            int NrOfAlbums = new int();

            if (categoryid == 0)
            {
                NrOfAlbums = this.NrOfAlbums();
            }
            else
            {
                NrOfAlbums = this.NrOfAlbums(categoryid);
            }

            return this.CalculateDecimal(NrOfAlbums, pagesize);
        }

        public int CalculatePagesForSearch(string title, int pagesize)
        {
            int NrOfAlbums = this.NrOfAlbums(title);
            return this.CalculateDecimal(NrOfAlbums, pagesize);
        }


    }
}
