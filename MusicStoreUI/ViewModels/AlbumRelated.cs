using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStoreUI.ViewModels
{
    public class AlbumRelated
    {
        public Album Album { get; set; }

        public List<Album> Related { get; set; }
    }
}