using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.Interfaces
{
    public interface IOrderRepository
    {
        void Create(Order Order);
        Order Delete(int Id);
        Order GetbyId(int id);
        List<Order> GetList();
    }
}