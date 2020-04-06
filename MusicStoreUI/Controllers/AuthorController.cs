using DomainModel.Interfaces;
using MusicStoreUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository authorRepository;

        // GET: Author
        public AuthorController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        public ActionResult Index()
        {
            var authors = authorRepository.GetList();
            return View(authors);
        }

        public ActionResult ByAuthor(int authorId, int page = 1, int pagesize = 3)
        {
            var author = authorRepository.GetbyId(authorId);
            var albums = authorRepository.GetAuthorAlbums(authorId, page, pagesize);
            var pagination = authorRepository.CalculatePages(authorId, pagesize);

            AuthorAlbum authorAlbum = new AuthorAlbum
            {
                Author = author,
                Albums = albums,
                Pagination = pagination
            };

            return View(authorAlbum);
        }
    }
}