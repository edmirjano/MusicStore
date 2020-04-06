using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomainModel.Models

{
    public class Category
    {
        [Key]
        public int CategorId { get; set; }
        [Required(ErrorMessage = "Please enter Category Title")]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}