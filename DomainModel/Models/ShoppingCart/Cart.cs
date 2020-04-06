using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel.Models;

namespace DomainModel.Models.ShoppingCart
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Album album, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Album.AlbumId == album.AlbumId).FirstOrDefault();

            if (line == null)
            {
                CartLine cartLine = new CartLine
                {
                    Album = album,
                    Quantity = quantity
                };

                lineCollection.Add(cartLine);
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public void RemoveLine(Album album)
        {
            lineCollection.RemoveAll(l => l.Album.AlbumId == album.AlbumId);
        }
        public double TotalPrice()
        {
            return lineCollection.Sum(e => e.Album.Price * e.Quantity);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }
        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }

    }
}