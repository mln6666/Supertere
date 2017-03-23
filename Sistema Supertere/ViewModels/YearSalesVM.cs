using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Supertere.ViewModels
{
    public class YearSalesVM
    {
        public DateTime YDate { get; set; }

        public List<MonthSalesVM> MonthSales { get; set; }

        public decimal YearSalesTotal { get; set; }

        public decimal YearGain { get; set; }

    }
}