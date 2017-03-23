using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Supertere.ViewModels
{
    public class MonthSalesVM
    {
        public DateTime MDate { get; set; }

        public List<DaySalesVM> DaySales { get; set; }

        public decimal MonthSalesTotal { get; set; }

        public decimal MonthGain { get; set; }


    }
}