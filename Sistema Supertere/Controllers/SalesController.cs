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
    public class SalesController : Controller
    {
        private TereContext db = new TereContext();

        // GET: Sales
        public ActionResult Index()
        {
            var sales = db.Sales.Include(s => s.Bill).Include(s => s.Customer);
            return View(sales.ToList());
        }

        // GET: Sales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        public ActionResult NewSale()
        {
           
            ViewBag.Customers = db.Customers.ToList();
            ViewBag.Products = db.Products.ToList();
            var nsale = 0;
            if (db.Sales != null & db.Sales.Count() != 0)
            {
                nsale = db.Sales.ToList().LastOrDefault().IdSale;
            }

            ViewBag.nsale = nsale + 1;


            return View();
        }


        // GET: Sales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBill = new SelectList(db.Bills, "IdBill", "SaleAddress", sale.IdBill);
            ViewBag.IdCustomer = new SelectList(db.Customers, "IdCustomer", "CustomerName", sale.IdCustomer);
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSale,SaleDate,SaleAddress,Discount,Comments,ReturnsTotal,LinesTotal,SubTotal,SaleTotal,IdCustomer,IdBill,SaleState")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBill = new SelectList(db.Bills, "IdBill", "SaleAddress", sale.IdBill);
            ViewBag.IdCustomer = new SelectList(db.Customers, "IdCustomer", "CustomerName", sale.IdCustomer);
            return View(sale);
        }

        // GET: Sales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sale sale = db.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sale sale = db.Sales.Find(id);
            db.Sales.Remove(sale);
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
