using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Supertere.Context;
using Sistema_Supertere.Models;
using Sistema_Supertere.ViewModels;

namespace Sistema_Supertere.Controllers
{
    public class InformationsController : Controller
    {
        private TereContext db = new TereContext();

        // GET: Informations
        [HttpPost]
        public ActionResult DaySales(DateTime date)
        {
            DaySalesVM ds=new DaySalesVM();
            ds.Date = date;
            ds.Sales = db.Sales.ToList().FindAll(x => x.SaleDate == date & x.SaleState != SaleState.Cuenta);
            ds.DaySalesTotal = 0;
            ds.DayGain = 0;

            foreach (var sale in ds.Sales)
            {
                foreach (var saleline in sale.SaleLines)
                {
                    ds.DaySalesTotal += saleline.LineTotal;
                }
                
            }
            ds.DayGain = ds.DaySalesTotal * 0.25m;


            return View(ds);
        }

        public ActionResult Index()
        {

            return View();
        }
    }
}