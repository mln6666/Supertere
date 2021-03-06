﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Supertere.Models
{
    public class Sale
    {
        [Key]
        public int IdSale { get; set; }

        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        public DateTime SaleDate { get; set; }
     

        [Display(Name = "Obs.")]
        public string Comments { get; set; }

        [Display(Name = "Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? SubTotal { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? SaleTotal { get; set; }

        public int? IdCustomer { get; set; } //Clave Foránea de Cliente (Customer)

        public virtual Customer Customer { get; set; }

        public virtual ICollection<SaleLine> SaleLines { get; set; }

        public virtual SaleState SaleState { get; set; }
}
}