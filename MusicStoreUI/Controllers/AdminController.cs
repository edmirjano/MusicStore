using DomainModel.Interfaces;
using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAlbumRepository albumRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IAuthorRepository authorRepository;
        private readonly IOrderRepository orderRepository;

        // GET: Admin
        public AdminController(IAlbumRepository albumRepository, ICategoryRepository categoryRepository, IAuthorRepository authorRepository, IOrderRepository orderRepository)
        {
            this.albumRepository = albumRepository;
            this.categoryRepository = categoryRepository;
            this.authorRepository = authorRepository;
            this.orderRepository = orderRepository;
        }
        public ActionResult Index()
        {
            ViewBag.Albums = albumRepository.GetList().Count();
            ViewBag.Orders = orderRepository.GetList().Count();
            ViewBag.Authors = authorRepository.GetList().Count();
            ViewBag.Categories = categoryRepository.GetList().Count();
            return View();
        }
        public ActionResult Albums(string message = "")
        {
            if (message.Length > 1)
            {
                ViewBag.message = message;
            }
            var albums = albumRepository.GetList();
            return View(albums);
        }
        public ActionResult Authors(string message = "")
        {
            if (message.Length > 1)
            {
                ViewBag.message = message;
            }
            var authors = authorRepository.GetList();
            return View(authors);
        }
        public ActionResult Categories(string message = "")
        {
            if (message.Length > 1)
            {
                ViewBag.message = message;
            }
            var categories = categoryRepository.GetList();
            return View(categories);
        }
        public ActionResult Orders(string message = "")
        {
            if (message.Length > 1)
            {
                ViewBag.message = message;
            }
            var orders = orderRepository.GetList();
            return View(orders);
        }
        public ActionResult DetailsAlbum(int id)
        {

            var album = albumRepository.GetbyId(id);

            return View(album);
        }
        public ActionResult DetailsAuthor(int id)
        {

            var author = authorRepository.GetbyId(id);

            return View(author);
        }
        public ActionResult DetailsCategory(int id)
        {

            var category = categoryRepository.GetbyId(id);

            return View(category);
        }
        public ActionResult EditAlbum(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var album = albumRepository.GetbyId(id);
            ViewBag.Authors = authorRepository.GetList();
            ViewBag.Categories = categoryRepository.GetList();
            return View(album);
        }
        public ActionResult EditAuthor(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var author = authorRepository.GetbyId(id);
            return View(author);
        }
        public ActionResult EditCategory(int id = 0)
        {
            if (id == 0)
            {
                return HttpNotFound();
            }
            var category = categoryRepository.GetbyId(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult EditAlbum(Album album, HttpPostedFileBase Image = null, int AuthorId = 0, int CategoryId = 0)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    string fileName = Path.GetFileName(Image.FileName);
                    string filePath = "~/Content/Images" + fileName;
                    album.ImagePath = filePath;
                    Image.SaveAs(Server.MapPath(filePath));
                }
                if (CategoryId != 0)
                {
                    album.CategoryId = CategoryId;
                }
                if (AuthorId != 0)
                {
                    album.AuthorId = AuthorId;
                }

                albumRepository.Create(album);

                string message = "Action Succeded";
                return RedirectToAction("Albums", new { message = message });
            }
            else
            {
                ViewBag.Authors = authorRepository.GetList();
                ViewBag.Categories = categoryRepository.GetList();
                return View(album);
            }
        }
        [HttpPost]
        public ActionResult EditAuthor(Author author)
        {
            if (ModelState.IsValid)
            {

                authorRepository.Create(author);

                string message = "Action Succeded";
                return RedirectToAction("Authors", new { message = message });
            }
            else
            {
                return View(author);
            }
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {

                categoryRepository.Create(category);

                string message = "Action Succeded";
                return RedirectToAction("Categories", new { message = message });
            }
            else
            {
                return View(category);
            }
        }
        public ActionResult DeleteAlbum(int id)
        {
            albumRepository.Delete(id);

            string message = "Album Deleted Succesfuly";
            return RedirectToAction("Albums", new { message = message });
        }
        public ActionResult DeleteAuthor(int id)
        {
            authorRepository.Delete(id);

            string message = "Author Deleted Succesfuly";
            return RedirectToAction("Authors", new { message = message });
        }
        public ActionResult DeleteCategory(int id)
        {
            categoryRepository.Delete(id);

            string message = "Category Deleted Succesfuly";
            return RedirectToAction("Categories", new { message = message });
        }
        public ActionResult DeleteOrder(int id)
        {
            orderRepository.Delete(id);

            string message = "Order Deleted Succesfuly";
            return RedirectToAction("Orders", new { message = message });
        }
        public ActionResult CreateAlbum()
        {
            ViewBag.Authors = authorRepository.GetList();
            ViewBag.Categories = categoryRepository.GetList();
            Album album = new Album();
            return View("EditAlbum", new Album());
        }
        public ActionResult CreateAuthor()
        {
            Author author = new Author();
            return View("EditAuthor", author);
        }
        public ActionResult CreateCategory()
        {
            Category category = new Category();
            return View("EditCategory", category);
        }
        public ActionResult MarkAsCompleted(int OrderId)
        {
            var order = orderRepository.GetbyId(OrderId);

            if (order != null)
            {

                order.Completed = !order.Completed;
                orderRepository.Create(order);
            }
            string message = "Order Status Updated Succesfuly";
            return RedirectToAction("Orders", new { message = message });
        }
    }
}