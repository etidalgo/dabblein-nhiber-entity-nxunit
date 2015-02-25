using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyCompany.Domain;
using System.Data.Entity;

namespace MyCompany.EF
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
