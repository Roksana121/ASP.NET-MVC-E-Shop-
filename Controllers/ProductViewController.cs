using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    [Authorize]
    public class ProductViewController : Controller
    {
        E_ShopDbContext db = new E_ShopDbContext();
        // GET: ProductView
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }
    }
}