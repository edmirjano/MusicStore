using DomainModel.Interfaces;
using DomainModel.Models;
using DomainModel.Models.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStoreUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IShippingDetailsRepository shippingDetailsRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderAlbumRepository orderAlbumRepository;

        public ShoppingCartController(IAlbumRepository albumRepository, IShippingDetailsRepository shippingDetailsRepository, IOrderRepository orderRepository, IOrderAlbumRepository orderAlbumRepository)
        {
            this.albumRepository = albumRepository;
            this.shippingDetailsRepository = shippingDetailsRepository;
            this.orderRepository = orderRepository;
            this.orderAlbumRepository = orderAlbumRepository;
        }

        public ActionResult AddToCart(int AlbumId)
        {
            var Album = albumRepository.GetbyId(AlbumId);

            if (Album != null)
            {
                GetCart().AddItem(Album, 1);
            }

            return View("Index", GetCart());
        }
        public ActionResult RemoveFromCart(int AlbumId)
        {
            var Album = albumRepository.GetbyId(AlbumId);
            if (Album != null)
            {
                GetCart().RemoveLine(Album);
            }
            return View("Index", GetCart());
        }
        public ActionResult Index()
        {
            return View(GetCart());
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        [Authorize]
        public ViewResult Checkout()
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.Message = "Admin Cannot perform checkout, please sign in again or register!";
                return View("Index", GetCart());
            }
            return View();
        }

        [HttpPost]
        public ViewResult Checkout(ShippingDetails shippingDetails)
        {
            if (ModelState.IsValid)
            {

                shippingDetailsRepository.Create(shippingDetails);

                Order order = new Order
                {
                    TotalAmaunt = (int)this.GetCart().TotalPrice(),
                    ShippingId = shippingDetails.ShippingId,
                    Completed = false
                };

                if (shippingDetails.CouponCode == "FREE")
                {
                    order.HasACoupon = true;
                    order.TotalAmaunt = 0;
                }

                orderRepository.Create(order);

                var cart = GetCart().Lines.ToList();

                var orderid = order.OrderId;

                foreach (var item in cart)
                {
                    OrderAlbum orderAlbum = new OrderAlbum
                    {
                        AlbumId = item.Album.AlbumId,
                        OrderId = orderid,
                        Quantity = item.Quantity
                    };

                    orderAlbumRepository.Create(orderAlbum);
                }



                GetCart().Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
    }
}