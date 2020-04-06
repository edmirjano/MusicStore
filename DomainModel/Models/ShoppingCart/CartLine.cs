using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DomainModel.Models;

namespace DomainModel.Models.ShoppingCart
{
    public class CartLine
    {
        public Album Album { get; set; }

        public int Quantity { get; set; }   
    }
}