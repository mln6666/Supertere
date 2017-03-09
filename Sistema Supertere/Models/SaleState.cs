using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MinimercadoAlfredo.Models
{
    public enum SaleState

    {
        [Display(Name = "Efectivo")]
        Efectivo = 0,

        [Display(Name = "Cta. Corriente")]
        Cuenta = 1,
        [Display(Name = "Tarjeta")]
        Tarjeta = 2


    }
}