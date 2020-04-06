using DomainModel.DbContext;
using DomainModel.Interfaces;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomainModel.Repositories
{
    public class ShippingDetailsRepository : IShippingDetailsRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        public void Create(ShippingDetails shippingDetails)
        {
            if (shippingDetails.ShippingId == 0)
            {
                _context.ShippingDetails.Add(shippingDetails);
            }
            else
            {
                ShippingDetails dbEntry = _context.ShippingDetails.Find(shippingDetails.ShippingId);
                if (dbEntry != null)
                {
                    dbEntry.Name = shippingDetails.Name;
                    dbEntry.Email = shippingDetails.Email;
                    dbEntry.Adress = shippingDetails.Adress;
                    dbEntry.Tel = shippingDetails.Tel;

                    _context.SaveChanges();
                }
            }
            _context.SaveChanges();
        }
        public ShippingDetails GetbyId(int id)
        {
            return _context.ShippingDetails.Find(id);
        }

        public ShippingDetails Delete(int Id)
        {
            ShippingDetails dbEntry = _context.ShippingDetails.Find(Id);
            if (dbEntry != null)
            {
                _context.ShippingDetails.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public List<ShippingDetails> GetList()
        {
            return _context.ShippingDetails.ToList();
        }
    }
}