using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel.Models

{
    public class OrderAlbum
    {
        [Key]
        public int OrderAlbumId { get; set; }
        [ForeignKey("Albums")]
        public int AlbumId { get; set; }
        public virtual Album Albums { get; set; }
        [ForeignKey("Orders")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Please enter Quanty")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be numeric")]
        public int Quantity { get; set; }
        public virtual Order Orders { get; set; }
    }
}