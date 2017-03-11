using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Sistema_Supertere.Context;
using Sistema_Supertere.Models;

namespace Sistema_Supertere
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest()
        {
            var currentCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            currentCulture.NumberFormat.NumberDecimalSeparator = ".";
            currentCulture.NumberFormat.NumberGroupSeparator = " ";
            currentCulture.NumberFormat.CurrencyDecimalSeparator = ".";

            Thread.CurrentThread.CurrentCulture = currentCulture;
            //Thread.CurrentThread.CurrentUICulture = currentCulture;
        }
        protected void Application_Start()
        {

            TereContext dc = new TereContext();
            if (dc.Customers == null | dc.Customers.Count() == 0)
            {
                Customer t1 = new Customer();
                Customer t2 = new Customer();
                Customer t3 = new Customer();
                Customer t4 = new Customer();
                Customer t5 = new Customer();
                t1.CustomerName = "Cliente 1";
                t2.CustomerName = "Cliente 2";
                t3.CustomerName = "Cliente 3";
                t4.CustomerName = "Cliente 4";
                t5.CustomerName = "Cliente 5";
                dc.Customers.Add(t1);
                dc.Customers.Add(t2);
                dc.Customers.Add(t3);
                dc.Customers.Add(t4);
                dc.Customers.Add(t5);
                dc.SaveChanges();
            }

            if (dc.Trademarks == null | dc.Trademarks.Count() == 0)
            {
                Trademark t1 = new Trademark();
                Trademark t2 = new Trademark();
                Trademark t3 = new Trademark();
                Trademark t4 = new Trademark();
                Trademark t5 = new Trademark();
                t1.TrademarkName = "Arcor";
                t2.TrademarkName = "Ala";
                t3.TrademarkName = "Kingston";
                t4.TrademarkName = "Coca Coca";
                t5.TrademarkName = "Okuma";
                dc.Trademarks.Add(t1);
                dc.Trademarks.Add(t2);
                dc.Trademarks.Add(t3);
                dc.Trademarks.Add(t4);
                dc.Trademarks.Add(t5);
                dc.SaveChanges();
            }
            if (dc.Categories == null | dc.Categories.Count() == 0)
            {
                Category t1 = new Category();
                Category t2 = new Category();
                Category t3 = new Category();
                Category t4 = new Category();
                Category t5 = new Category();
                Category t6 = new Category();

                t1.CategoryName = "Pesca";
                t2.CategoryName = "Bebidas";
                t3.CategoryName = "Tecnología";
                t4.CategoryName = "Comestibles";
                t5.CategoryName = "Limpieza";
                t6.CategoryName = "Varios";

                dc.Categories.Add(t1);
                dc.Categories.Add(t2);
                dc.Categories.Add(t3);
                dc.Categories.Add(t4);
                dc.Categories.Add(t5);
                dc.Categories.Add(t6);
                dc.SaveChanges();
            }
            if (dc.Products == null | dc.Products.Count() == 0)
            {
                Product t1 = new Product();
                Product t2 = new Product();
                Product t3 = new Product();
                Product t4 = new Product();
                Product t5 = new Product();
                t1.ProductDescription = "Caña 1.20m";
                t1.Barcode = "1112223334445";
                t1.Cost = 100;
                t1.PublicPrice =150;
                t1.Stock = 10;
                t1.Minimum =1;
                t1.ProductState = true;
                t1.idCategory = 1;
                t1.IdTrademark = 5;

                t2.ProductDescription = "Coca 3L";
                t2.Barcode = "4442225556668";
                t2.Cost = 35;
                t2.PublicPrice = 50;
                t2.Stock = 50;
                t2.Minimum = 5;
                t2.ProductState = true;
                t2.idCategory = 2;
                t2.IdTrademark = 4;

                t3.ProductDescription = "Pendrive 16gb";
                t3.Barcode = "7774448889996";
                t3.Cost = 120;
                t3.PublicPrice = 190;
                t3.Stock = 15;
                t3.Minimum = 5;
                t3.ProductState = true;
                t3.idCategory = 3;
                t3.IdTrademark = 3;

                t4.ProductDescription = "Serranas";
                t4.Barcode = "8882224443337";
                t4.Cost = 16;
                t4.PublicPrice = 25;
                t4.Stock = 30;
                t4.Minimum = 5;
                t4.ProductState = true;
                t4.idCategory = 4;
                t4.IdTrademark = 1;

                t5.ProductDescription = "Detergente";
                t5.Barcode = "4443339991116";
                t5.Cost = 19;
                t5.PublicPrice = 37;
                t5.Stock = 20;
                t5.Minimum = 5;
                t5.ProductState = true;
                t5.idCategory = 5;
                t5.IdTrademark = 2;

                dc.Products.Add(t1);
                dc.Products.Add(t2);
                dc.Products.Add(t3);
                dc.Products.Add(t4);
                dc.Products.Add(t5);
                dc.SaveChanges();
            }


            
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
