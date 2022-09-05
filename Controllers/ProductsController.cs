
using CrystalDecisions.CrystalReports.Engine;
using E_Shop.Models;
using E_Shop.Models.ViewModels;

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
//using System.E_Shop;

namespace E_Shop.Controllers
{

    [Authorize]
    public class ProductsController : Controller
    {
        E_ShopDbContext db = new E_ShopDbContext();
        // GET: Products
      
        public ActionResult Index() //int page=1
        {
            //ViewBag.totalPages = (int)Math.Ceiling((double)db.Products.Count()/5);
            //ViewBag.currentPage = page;
            //return View(db.Products.OrderBy(x => x.ProductId).Skip((page - 1) *5).Take(5).ToList());
            return View(db.Products.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.CategorId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                if (productVM.Picture != null)
                {
                    string filePath = Path.Combine("~/Images", Guid.NewGuid().ToString()
                        + Path.GetExtension(productVM.Picture.FileName));
                    productVM.Picture.SaveAs(Server.MapPath(filePath));

                    Product product = new Product
                    {
                        ProductName = productVM.ProductName,
                        Price = productVM.Price,
                        Quantity = productVM.Quantity,
                        isAvailable = productVM.isAvailable,
                        SalesDate = productVM.SalesDate,
                        ProductPhoto = filePath,
                        CategoryId = productVM.CategoryId
                    };

                    db.Products.Add(product);
                    db.SaveChanges();
                    return PartialView("_success");
                }


            }
            ViewBag.CategorId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return PartialView("_error");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);


            if (product == null)
            {
                return HttpNotFound();
            }
            ProductVM productVM = new ProductVM
            {
                ProductName = product.ProductName,
                Price = product.Price,
                Quantity = product.Quantity,
                isAvailable = product.isAvailable,
                SalesDate = product.SalesDate,
                ProductPhoto = product.ProductPhoto,
                CategoryId = (int)product.CategoryId
            };
            ViewBag.CategorId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View(productVM);
        }
        [HttpPost]
        public ActionResult Edit(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                string filePath = productVM.ProductPhoto;
                if (productVM.Picture != null)
                {
                    filePath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(productVM.Picture.FileName));
                    productVM.Picture.SaveAs(Server.MapPath(filePath));

                    Product product = new Product
                    {

                        ProductName = productVM.ProductName,
                        Price = productVM.Price,
                        Quantity = productVM.Quantity,
                        isAvailable = productVM.isAvailable,
                        SalesDate = productVM.SalesDate,
                        ProductPhoto = filePath,
                        CategoryId = productVM.CategoryId
                    };
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    Product product = new Product
                    {
                        ProductName = productVM.ProductName,
                        Price = productVM.Price,
                        Quantity = productVM.Quantity,
                        isAvailable = productVM.isAvailable,
                        SalesDate = productVM.SalesDate,
                        ProductPhoto = filePath,
                        CategoryId = productVM.CategoryId
                    };
                    db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CategorId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            return View(productVM);
        }


        public ActionResult Delete(int? id)
        {
            ViewBag.CategorId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)

        {

            Product product = db.Products.Find(id);
            string file_name = product.ProductPhoto;
            string path = Server.MapPath(file_name);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       public ActionResult Report()
        {
            var db = new E_ShopDbContext();
            var ListProduct = (from p in db.Products
                               join c in db.Categories on p.CategoryId equals
                                c.CategoryId
                               //where x.ProductId == id

                               select new ProductVM
                               {
                                   ProductId = p.ProductId,
                                   ProductName = p.ProductName,
                                   Price = p.Price,
                                   Quantity = p.Quantity,
                                   isAvailable = p.isAvailable,
                                   SalesDate = p.SalesDate,
                                   //ProductPhoto = "/*http://localhost:54272*/"+p.ProductPhoto,
                                   ProductPhoto = p.ProductPhoto,
                                   CategoryId = c.CategoryId,
                                  
                               }).Distinct().ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReport"), "ProductReport.rpt"));
            rd.SetDataSource(ListToDataTable(ListProduct));
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "ProductList.pdf");
            }
            catch
            {
                throw;
            }
        }


        private DataTable ListToDataTable<T>(List<T> items)
        {
            DataTable datatable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                datatable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                datatable.Rows.Add(values);
            }
            return datatable;
        }
    }
    
}