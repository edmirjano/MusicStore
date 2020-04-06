using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel.Interfaces;
using MusicStoreUI.ViewModels;
using DomainModel.Models;

namespace MusicStoreUI.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly ICategoryRepository categoryRepository;
        public List<Category> CategoryList;
        // GET: Album
        public AlbumController(IAlbumRepository albumRepository, IAuthorRepository authorRepository, ICategoryRepository categoryRepository)
        {
            this.albumRepository = albumRepository;
            this.authorRepository = authorRepository;
            this.categoryRepository = categoryRepository;
            this.CategoryList = categoryRepository.GetList();
        }
        public ActionResult Index(int page = 1, int pagesize = 3)
        {
            var albums = albumRepository.GetList(page, pagesize);
            var Pagination = albumRepository.CalculatePages(0, pagesize);



            AlbumAuthorCategory _albumAuthorCategory = new AlbumAuthorCategory
            {
                Albums = albums,
                Categories = CategoryList,
                Pagination = Pagination
            };

            return View(_albumAuthorCategory);


        }
        public ActionResult ByCategory(int categoryid = 0, int page = 1, int pagesize = 3)
        {
            var albums = new List<Album>();
            var Pagination = albumRepository.CalculatePages(categoryid, pagesize);
            var currentCategory = categoryRepository.GetbyId(categoryid);
            if (categoryid == 0)
            {
                albums = albumRepository.GetList(page, pagesize);
            }
            else
            {
                albums = albumRepository.GetByCategory(categoryid, page, pagesize);
            }

            AlbumAuthorCategory albumAuthorCategory = new AlbumAuthorCategory
            {
                Albums = albums,
                Categories = CategoryList,
                Pagination = Pagination,
                CurrentCategory = currentCategory
            };

            return View("Index", albumAuthorCategory);
        }

        public ActionResult SingleAlbum(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var albumi = albumRepository.GetbyId(id);
            var related = albumRepository.GetRelated(albumi.CategoryId);

            AlbumRelated albumRelated = new AlbumRelated
            {
                Album = albumi,
                Related = related
            };

            return View(albumRelated);
        }

        public ActionResult SearchAlbum(string title, int page = 1, int pagesize = 3)
        {

            var albums = albumRepository.SearchByTitle(title, page, pagesize);
            var Pagination = albumRepository.CalculatePagesForSearch(title, pagesize);

            AlbumAuthorCategory albumAuthorCategory = new AlbumAuthorCategory
            {
                Albums = albums,
                Categories = CategoryList,
                Pagination = Pagination,
                SearchKeyword = title
            };

            return View("Index", albumAuthorCategory);
        }

    }
}