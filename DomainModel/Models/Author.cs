using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomainModel.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Please enter Author Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Authors Age")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be numeric")]
        public int? Age { get; set; }
        public virtual List<Album> Albums { get; set; }
    }
}