using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Please enter Album Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Year")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be numeric")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter Price")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be numeric")]
        public int Price { get; set; }

        public int? NrOfSongs { get; set; }

        public string ImagePath { get; set; }

        public bool OnSale { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Author Author { get; set; }
        public virtual Category Category { get; set; }

    }
}