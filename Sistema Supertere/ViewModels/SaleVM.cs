using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sistema_Supertere.Models;

namespace Sistema_Supertere.ViewModels
{
    public class SaleVM
    {
        public int IdSale { get; set; }

        public string CustomerName { get; set; }

        public DateTime SaleDate { get; set; }

        public List<SaleLine> SaleLines { get; set; }

        public decimal SaleTotal { get; set; }

        public string Comments { get; set; }

        public string SaleState { get; set; }


    }
}