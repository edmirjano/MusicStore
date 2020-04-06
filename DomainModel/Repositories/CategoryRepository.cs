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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        public void Create(Category category)
        {
            if (category.CategorId == 0)
            {
                _context.Categories.Add(category);
            }
            else
            {
                Category dbEntry = _context.Categories.Find(category.CategorId);
                if (dbEntry != null)
                {
                    dbEntry.Name = category.Name;
                    dbEntry.Description = category.Description;

                    _context.SaveChanges();
                }
            }
            _context.SaveChanges();
        }
        public Category GetbyId(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category Delete(int Id)
        {
            Category dbEntry = _context.Categories.Find(Id);
            if (dbEntry != null)
            {
                _context.Categories.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public List<Category> GetList()
        {
            return _context.Categories.ToList();
        }
    }
}
