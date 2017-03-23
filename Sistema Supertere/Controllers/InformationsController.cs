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
        public ActionResult DaySales(DateTime date)
        {
            DaySalesVM ds = new DaySalesVM();
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

        [HttpPost]
        [ActionName("DaySales")]
        public ActionResult DaySalesPost(DateTime date)
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
        public ActionResult MonthSales(DateTime date)
        {
            //var salesm = db.Sales.ToList().FindAll(x => x.SaleDate.Month == date.Month &x.SaleDate.Year==date.Year & x.SaleState != SaleState.Cuenta);


            MonthSalesVM ms = new MonthSalesVM();
            ms.MDate = date;
            ms.MonthSalesTotal = 0;
            ms.MonthGain = 0;
            List<DaySalesVM> lista = new List<DaySalesVM>();
            int days = DateTime.DaysInMonth(date.Year, date.Month);

            for (int day = 1; day <= days; day++)
            {
                DaySalesVM ds = new DaySalesVM();
                ds.Date = new DateTime(date.Year, date.Month, day);
                ds.Sales = db.Sales.ToList().FindAll(x => x.SaleDate == ds.Date & x.SaleState != SaleState.Cuenta);
                ds.DaySalesTotal = 0;
                ds.DayGain = 0;

                if (ds.Sales.Count > 0)
                {
                    foreach (var item in ds.Sales)
                    {
                        foreach (var saleline in item.SaleLines)
                        {
                            ds.DaySalesTotal += saleline.LineTotal;
                        }
                    }
                    ds.DayGain = ds.DaySalesTotal * 0.25m;
                    ms.MonthSalesTotal += ds.DaySalesTotal;
                }
                lista.Add(ds);

            }
            ms.DaySales = lista;
            ms.MonthGain = ms.MonthSalesTotal * 0.25m;

            return View(ms);
        }
        [HttpPost]
        [ActionName("MonthSales")]
        public ActionResult MonthSalesPost(DateTime date)
        {
            //var salesm = db.Sales.ToList().FindAll(x => x.SaleDate.Month == date.Month &x.SaleDate.Year==date.Year & x.SaleState != SaleState.Cuenta);


            MonthSalesVM ms = new MonthSalesVM();
            ms.MDate = date;
            ms.MonthSalesTotal = 0;
            ms.MonthGain = 0;
            List<DaySalesVM> lista= new List<DaySalesVM>();
            int days = DateTime.DaysInMonth(date.Year, date.Month);

            for (int day = 1; day <= days; day++)
            {
                DaySalesVM ds = new DaySalesVM();
                ds.Date = new DateTime(date.Year,date.Month,day);
                ds.Sales = db.Sales.ToList().FindAll(x => x.SaleDate == ds.Date & x.SaleState != SaleState.Cuenta);
                ds.DaySalesTotal = 0;
                ds.DayGain = 0;

                if (ds.Sales.Count > 0) { 
                foreach (var item in ds.Sales)
                {
                    foreach (var saleline in item.SaleLines)
                    {
                        ds.DaySalesTotal += saleline.LineTotal;
                    }
                }
                    ds.DayGain = ds.DaySalesTotal * 0.25m;
                    ms.MonthSalesTotal += ds.DaySalesTotal;
                }
                lista.Add(ds);

            }
            ms.DaySales = lista;
            ms.MonthGain = ms.MonthSalesTotal * 0.25m;

            return View(ms);
        }

        [HttpPost]
        public ActionResult YearSales(DateTime date)
        {
            //var salesm = db.Sales.ToList().FindAll(x => x.SaleDate.Month == date.Month &x.SaleDate.Year==date.Year & x.SaleState != SaleState.Cuenta);


            YearSalesVM ys = new YearSalesVM();
            ys.YDate = date;
            ys.YearSalesTotal = 0;
            ys.YearGain = 0;
            List<MonthSalesVM> lista = new List<MonthSalesVM>();
            int months =12;

            for (int month = 1; month <= months; month++)
            {
                MonthSalesVM ms = new MonthSalesVM();
                ms.MDate = new DateTime(date.Year, month, 1);
                var salesm = db.Sales.ToList().FindAll(x => x.SaleDate.Year == date.Year & x.SaleDate.Month==month & x.SaleState != SaleState.Cuenta);
                ms.MonthSalesTotal = 0;
                ms.MonthGain = 0;

                if (salesm.Count() > 0)
                {
                    foreach (var item in salesm)
                    {
                        foreach (var saleline in item.SaleLines)
                        {
                            ms.MonthSalesTotal += saleline.LineTotal;
                        }
                    }
                    ms.MonthGain = ms.MonthSalesTotal * 0.25m;
                    ys.YearSalesTotal += ms.MonthSalesTotal;
                }
                lista.Add(ms);

            }
            ys.MonthSales = lista;
            ys.YearGain = ys.YearSalesTotal * 0.25m;

            return View(ys);
        }


        public ActionResult Index()
        {

            return View();
        }
    }
}