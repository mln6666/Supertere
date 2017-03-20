using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sistema_Supertere.Models;

namespace Sistema_Supertere.ViewModels
{
    public class DaySalesVM
    {
        public DateTime Date { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public decimal DaySalesTotal { get; set; }

        public decimal DayGain { get; set; }



    }
}