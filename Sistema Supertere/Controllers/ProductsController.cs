using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Supertere.Context;
using Sistema_Supertere.Models;

namespace Sistema_Supertere.Controllers
{
    public class ProductsController : Controller
    {
        private TereContext db = new TereContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.ToList().FindAll(x=>x.ProductState==true );
            return View(products);
        }
        public ActionResult IndexDeac()
        {
            var products = db.Products.ToList().FindAll(x => x.ProductState == false);
            return View(products);
        }
        public ActionResult IndexAll(int? x)
        {
           
                if (x != null)
                {
                    TempData["mimsg"] = x; return RedirectToAction("IndexAll");
                }
            
            var products = db.Products.ToList();
            return View(products);
        }
        public JsonResult ExBarcode(string bc)
        {
            //if (Trademark == "")
            //    Trademark = "[Producto sin Marca]";
            var existe = db.Products.ToList().Exists(a => a.Barcode == bc);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExBarcodeEdit(string bc,int id)
        {
            //if (Trademark == "")
            //    Trademark = "[Producto sin Marca]";
            var existe = db.Products.ToList().Exists(a => a.Barcode == bc & a.IdProduct!=id);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExProduct(string des,int mar)
        {
            //if (Trademark == "")
            //    Trademark = "[Producto sin Marca]";
            var existe = db.Products.ToList().Exists(a => a.ProductDescription == des & a.IdTrademark==mar);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ExProductEdit(string des, int mar,int id)
        {
            //if (Trademark == "")
            //    Trademark = "[Producto sin Marca]";
            var existe = db.Products.ToList().Exists(a => a.ProductDescription == des & a.IdTrademark == mar &a.IdProduct!=id);

            return Json(existe, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Getproductdata(string pro)
        {
           

            var proid = Int32.Parse(pro);


            Product productdata = db.Products.ToList().Find(u => u.IdProduct == proid);


            var midato = productdata.PublicPrice.ToString();

            return Json(midato, JsonRequestBehavior.AllowGet);
        }
        public JsonResult VerifDeleteP(int id)
        {

            bool verif = false;


            Product productdata = db.Products.ToList().Find(u => u.IdProduct == id);
            if (productdata.SaleLines != null & productdata.SaleLines.Count() > 0)
            {
                verif = true;}


            return Json(verif, JsonRequestBehavior.AllowGet);
        }
        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

    
        [HttpPost]
        public JsonResult Deactivate(int? id)
        {
            var status = false;
            Product prod = new Product();
            prod = db.Products.Find(id);

            prod.ProductState = !prod.ProductState;
            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();
            status = true;
            return Json(status, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult Activate(int? id)
        {
            var status = false;
            Product prod = new Product();
            prod = db.Products.Find(id);

            prod.ProductState = !prod.ProductState;
            db.Entry(prod).State = EntityState.Modified;
            db.SaveChanges();
            status = true;
            return Json(status, JsonRequestBehavior.AllowGet);

        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.idCategory = new SelectList(db.Categories, "IdCategory", "CategoryName");
            ViewBag.IdTrademark = new SelectList(db.Trademarks, "IdTrademark", "TrademarkName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProduct,ProductDescription,Barcode,Cost,PublicPrice,UploadDate,Stock,Minimum,ProductState,Image,idCategory,IdTrademark")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategory = new SelectList(db.Categories, "IdCategory", "CategoryName", product.idCategory);
            ViewBag.IdTrademark = new SelectList(db.Trademarks, "IdTrademark", "TrademarkName", product.IdTrademark);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategory = new SelectList(db.Categories, "IdCategory", "CategoryName", product.idCategory);
            ViewBag.IdTrademark = new SelectList(db.Trademarks, "IdTrademark", "TrademarkName", product.IdTrademark);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProduct,ProductDescription,Barcode,Cost,PublicPrice,UploadDate,Stock,Minimum,ProductState,Image,idCategory,IdTrademark")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategory = new SelectList(db.Categories, "IdCategory", "CategoryName", product.idCategory);
            ViewBag.IdTrademark = new SelectList(db.Trademarks, "IdTrademark", "TrademarkName", product.IdTrademark);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
