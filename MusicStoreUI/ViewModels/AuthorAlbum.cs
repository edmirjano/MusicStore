using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreUI.ViewModels
{
    public class AuthorAlbum
    {
        public List<Album> Albums { get; set; }

        public Author Author { get; set; }
        public int Pagination { get; set; }

    }
}