using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_Supertere.Context
{
    public class TereContext : DbContext

    {
        public TereContext()
            : base("name=TereContext")
        {
        }


        public System.Data.Entity.DbSet<Sistema_Supertere.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.Provider> Providers { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.Sale> Sales { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.SaleLine> SaleLines { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.PurchaseLine> PurchaseLines { get; set; }

        public System.Data.Entity.DbSet<Sistema_Supertere.Models.Trademark> Trademarks { get; set; }
    }
}