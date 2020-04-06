using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreUI.ViewModels
{
    public class AlbumAuthorCategory
    {
        public List<Album> Albums { get; set; }
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
        public int Pagination { get; set; }

        public Category CurrentCategory { get; set; }
        public string SearchKeyword { get; set; }



    }
}