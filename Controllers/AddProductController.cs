using E_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Shop.Controllers
{
   
    public class AddProductController : Controller
    {
        //GET: AddProduct
        //[HttpGet]
        //public ActionResult Crud(int? id)
        //{
        //    var db = new E_ShopDbContext();
        //    var oProduct = (from o in db.Products where o.ProductId == id select o).FirstOrDefault();
        //    oProduct = oProduct == null ? new Product() : oProduct;
        //    ViewData["List"] = db.Products.ToList();
        //    ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Crud(Product E_ShopDbContext, HttpPostedFileBase Picture)
        //{
        //    string fileName = "";
        //    if (Picture != null)
        //    {
        //        fileName = Picture.FileName;
        //        // To save a image to a folder
        //        string picture = System.IO.Path.GetFileName(Picture.FileName);
        //        string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
        //        Picture.SaveAs(path);
        //    }
        //    var db = new E_ShopDbContext();
        //    var oProduct = db.Products.Find(E_ShopDbContext.ProductId);
        //    ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
        //    if (oProduct == null)
        //    {
        //        #region insert
        //        E_ShopDbContext.ProductPhoto = "/Photo/" + fileName;
        //        db.Products.Add(E_ShopDbContext);
        //        #endregion
        //        ViewBag.Message = "inserted successfully.";
        //    }
        //    else
        //    {
        //        #region update
        //        oProduct.ProductName = E_ShopDbContext.ProductName;
        //        oProduct.Price = E_ShopDbContext.Price;
        //        oProduct.Quantity = E_ShopDbContext.Quantity;
        //        oProduct.isAvailable = E_ShopDbContext.isAvailable;
        //        oProduct.SalesDate = E_ShopDbContext.SalesDate;
        //        oProduct.ProductPhoto = "/Images/" + fileName;
        //        oProduct.CategoryId = E_ShopDbContext.CategoryId;
        //        #endregion
        //        ViewBag.Message = "updated successfully.";

        //    }

        //    db.SaveChanges();
        //    ViewData["ICollection"] = db.Products.ToList();
        //    return RedirectToAction("Crud");
        //}
        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    var db = new E_ShopDbContext();
        //    var oProduct = (from o in db.Products where o.ProductId == id select o).FirstOrDefault();
        //    if (oProduct != null)
        //    {
        //        db.Products.Remove(oProduct);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Crud");
        //}




        //public ActionResult Crud(int? id)
        //{
        //    var db = new E_ShopDbContext();
        //    var pProduct = (from p in db.Products where p.ProductId == id select p).FirstOrDefault();
        //    pProduct = pProduct == null ? new Product() : pProduct;
        //    ViewData["List"] = db.Products.ToList();
        //    ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Crud(Product E_ShopDbContext, HttpPostedFileBase Picture)
        //{
        //    string fileName = "";
        //    if (Picture != null)
        //    {
        //        fileName = Picture.FileName;
        //        // To save a image to a folder
        //        string picture = System.IO.Path.GetFileName(Picture.FileName);
        //        string path = System.IO.Path.Combine(Server.MapPath("~/Images"), picture);
        //        Picture.SaveAs(path);
        //    }
        //    var db = new E_ShopDbContext();
        //    var pProduct = db.Products.Find(E_ShopDbContext.ProductId);
        //    ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
        //    if (pProduct == null)
        //    {
        //        #region insert
        //        E_ShopDbContext.ProductPhoto = "/Images/" + fileName;
        //        db.Products.Add(E_ShopDbContext);
        //        #endregion
        //        ViewBag.Message = "inserted successfully.";
        //    }
        //    else
        //    {
        //        #region update
        //        pProduct.ProductName = E_ShopDbContext.ProductName;
        //        pProduct.Price = E_ShopDbContext.Price;
        //        pProduct.Quantity = E_ShopDbContext.Quantity;
        //        pProduct.isAvailable = E_ShopDbContext.isAvailable;
        //        pProduct.SalesDate = E_ShopDbContext.SalesDate;
        //        pProduct.ProductPhoto = "/Images/" + fileName;
        //        pProduct.CategoryId = E_ShopDbContext.CategoryId;
        //        #endregion
        //        ViewBag.Message = "updated successfully.";

        //    }

        //    db.SaveChanges();
        //    ViewData["ICollection"] = db.Products.ToList();
        //    return RedirectToAction("Crud");
        //}
        //[HttpGet]
        //public ActionResult Delete(int? id)
        //{
        //    var db = new E_ShopDbContext();
        //    var pProduct = (from p in db.Products where p.ProductId == id select p).FirstOrDefault();
        //    if (pProduct != null)
        //    {
        //        db.Products.Remove(pProduct);
        //        db.SaveChanges();
        //    }
        //    return RedirectToAction("Crud");
        //}
    }
}