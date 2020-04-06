using DomainModel.DbContext;
using DomainModel.Interfaces;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.Repositories
{
    public class OrderAlbumRepository : IOrderAlbumRepository
    {

        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public void Create(OrderAlbum orderAlbum)
        {
            if (orderAlbum.OrderAlbumId == 0)
            {
                _context.OrderAlbums.Add(orderAlbum);
            }
            else
            {
                OrderAlbum dbEntry = _context.OrderAlbums.Find(orderAlbum.OrderAlbumId);
                if (dbEntry != null)
                {
                    dbEntry.AlbumId = orderAlbum.AlbumId;
                    dbEntry.OrderId = orderAlbum.OrderId;
                    dbEntry.Quantity = orderAlbum.Quantity;

                    _context.SaveChanges();
                }
            }

            _context.SaveChanges();
        }
        public OrderAlbum GetbyId(int id)
        {
            return _context.OrderAlbums.Find(id);
        }

        public OrderAlbum Delete(int Id)
        {
            OrderAlbum dbEntry = _context.OrderAlbums.Find(Id);
            if (dbEntry != null)
            {
                _context.OrderAlbums.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public List<OrderAlbum> GetList()
        {
            return _context.OrderAlbums.ToList();
        }
    }
}