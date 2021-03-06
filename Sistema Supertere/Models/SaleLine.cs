﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Supertere.Models
{
    public class SaleLine
    {
        [Key]
        public int IdSaleLine { get; set; }

        public int IdProduct { get; set; } //Clave Foránea Producto

        public virtual Product Product { get; set; }

        public decimal LinePrice { get; set; }

        public decimal LineQuantity { get; set; }

        public decimal LineTotal { get; set; }

        public int IdSale { get; set; }

        public virtual Sale Sale { get; set; }

    }
}