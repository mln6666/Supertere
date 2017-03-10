﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Supertere.Models
{
    public class Product
    {
        [Key]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [Display(Name = "Descripción")]
        public string ProductDescription { get; set; }
      
        [Display(Name = "Cód. Barras")]
        public string Barcode { get; set; }

        [Display(Name = "P. Costo")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? Cost { get; set; }

        [Display(Name = "P. Venta")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal? PublicPrice { get; set; }

        [Display(Name = "Última Actualización")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime? UploadDate { get; set; }

        public decimal? Stock { get; set; }

        //public decimal? ParcialStock { get; set; }

        [Display(Name = "Stock mínimo")]
        public decimal? Minimum { get; set; }

        public bool ProductState { get; set; }

        public string Image { get; set; }

        public int idCategory { get; set; } //Clave Foránea de Category

        public virtual Category Category { get; set; }

        public int? IdTrademark { get; set; } //Clave Foránea de Category

        public virtual Trademark Trademark { get; set; }


        public virtual ICollection<PurchaseLine> PurchaseLines { get; set; }

        public virtual ICollection<SaleLine> SaleLines { get; set; }

        public virtual ICollection<ProductProvider> Providers { get; set; }

        public virtual ICollection<BillLine> BillLines { get; set; }


    }
}