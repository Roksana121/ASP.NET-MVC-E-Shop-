using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        E_ShopDbContext db = new E_ShopDbContext();
        // GET: OrderDetails
        public ActionResult Index()

        {


            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View(db.OrderDetails.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View(orderDetail);
        }
        public ActionResult Edit(int? id)
        {

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            //Customer customer = db.Customers.Find(id);
            //Product product = db.Products.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }

            return View(orderDetail);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,CustomerId,ProductId,Price,Quantity,OrderDate")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            return View(orderDetail);
        }

        public ActionResult Delete(int? id)
            {

                OrderDetail orderDetail = db.OrderDetails.Find(id);
                ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
                ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
                return View(orderDetail);
            }

            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                OrderDetail orderDetail = db.OrderDetails.Find(id);
                db.OrderDetails.Remove(orderDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        
    }
}




