using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(Category category);
        Category Delete(int Id);
        Category GetbyId(int id);
        List<Category> GetList();
    }
}