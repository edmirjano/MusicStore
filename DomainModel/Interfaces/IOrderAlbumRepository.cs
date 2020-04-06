using DomainModel.Models;
using System.Collections.Generic;

namespace DomainModel.Interfaces
{
    public interface IOrderAlbumRepository
    {
        void Create(OrderAlbum orderAlbum);
        OrderAlbum Delete(int Id);
        OrderAlbum GetbyId(int id);
        List<OrderAlbum> GetList();
    }

}