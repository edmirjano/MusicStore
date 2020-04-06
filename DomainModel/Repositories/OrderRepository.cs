using DomainModel.DbContext;
using DomainModel.Interfaces;
using DomainModel.Models;
using DomainModel.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();




        public void Create(Order Order)
        {
            if (Order.OrderId == 0)
            {
                _context.Orders.Add(Order);
            }
            else
            {
                Order dbEntry = _context.Orders.Find(Order.OrderId);
                if (dbEntry != null)
                {
                    dbEntry.TotalAmaunt = Order.TotalAmaunt;
                    dbEntry.Completed = Order.Completed;
                    dbEntry.HasACoupon = dbEntry.HasACoupon;

                    _context.SaveChanges();
                }
            }
            _context.SaveChanges();
        }
        public Order GetbyId(int id)
        {
            return _context.Orders.Find(id);
        }

        public Order Delete(int Id)
        {
            Order dbEntry = _context.Orders.Find(Id);
            if (dbEntry != null)
            {
                _context.Orders.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public List<Order> GetList()
        {
            return _context.Orders.ToList();
        }
    }
}
