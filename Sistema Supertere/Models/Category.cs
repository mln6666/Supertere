using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sistema_Supertere.Models
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        [Display(Name = "Rubro")]
        [Required(ErrorMessage = "Requerido")]
        public string CategoryName { get; set; }

        [DataType(DataType.MultilineText)]
        public string CategoryDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }

    }
}