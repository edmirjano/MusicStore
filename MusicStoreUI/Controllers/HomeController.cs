using DomainModel.Interfaces;
using MusicStoreUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumRepository albumRepository;

        public HomeController(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }
        public ActionResult Index()
        {
            var onsale = albumRepository.AlbumsOnSale();
            return View(onsale);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}