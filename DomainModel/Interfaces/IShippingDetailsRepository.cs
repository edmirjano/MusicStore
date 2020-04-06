using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.Interfaces
{
    public interface IShippingDetailsRepository
    {
        void Create(ShippingDetails shippingDetails);
        ShippingDetails Delete(int Id);
        ShippingDetails GetbyId(int id);
        List<ShippingDetails> GetList();
    }
}