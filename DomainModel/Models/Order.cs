using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel.Models

{
    public class Order
    {

        [Key]
        public int OrderId { get; set; }
        public int TotalAmaunt { get; set; }

        [ForeignKey("shippingDetails")]
        public int ShippingId { get; set; }
        public bool HasACoupon { get; set; }
        public bool Completed { get; set; }
        public virtual ShippingDetails shippingDetails { get; set; }
        public virtual List<OrderAlbum> OrderAlbum { get; set; }
    }
}