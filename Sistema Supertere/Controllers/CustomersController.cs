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
    public class CustomersController : Controller
    {
        private TereContext db = new TereContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }
        public ActionResult Unpaid()
        {
            var clist = db.Customers.ToList().FindAll(c=>c.Sales.ToList().Any(s=>s.SaleState==SaleState.Cuenta));

            foreach (var item in clist)
            {
                item.Unpaidtotal = 0;
                foreach (var sale in item.Sales)
                {
                    if (sale.SaleState == SaleState.Cuenta)
                    {
                        item.Unpaidtotal += sale.SaleTotal;
                    }
                    else
                    {
                        if (sale.SaleState == SaleState.Efectivo | sale.SaleState==SaleState.Tarjeta)
                        {
                            item.Sales.Remove(sale);
                        }
                    }
                }
                
            }

            return View(clist);
        }
        public ActionResult UnpaidDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            customer.Unpaidtotal = 0;
            foreach (var sale in customer.Sales)
            {
                if (sale.SaleState == SaleState.Cuenta)
                {
                    customer.Unpaidtotal += sale.SaleTotal;
                }
                else
                {
                    if (sale.SaleState == SaleState.Efectivo | sale.SaleState == SaleState.Tarjeta)
                    {
                        customer.Sales.Remove(sale);
                    }
                }
            }


            return View(customer);
        }


        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCustomer,CustomerName,CustomerAddress,CustomerPhone,CustomerEmail,CuitCuil")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCustomer,CustomerName,CustomerAddress,CustomerPhone,CustomerEmail,CuitCuil")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
