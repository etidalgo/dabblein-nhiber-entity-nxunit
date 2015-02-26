using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using MyCompany.Domain;
using MyCompany.EF;

namespace MyCompany.Tests
{
    [TestFixture]
    class TestFixture_EF_dbcontext
    {
        public TestFixture_EF_dbcontext()
        {
            using (var db = new ProductContext())
            {
                db.Products.RemoveRange(db.Products.Select(prod => prod));
                db.SaveChanges();
            }
        }

        [Test]
        public void Test_AddProduct()
        {
            using (var db = new ProductContext())
            {
                // Create and save a new Product 
                var product = new Product { Name = "Apple", Category = "Fruits" };
                db.Products.Add(product);
                db.SaveChanges();

                // Display all Products from the database 
                var query = from b in db.Products
                            orderby b.Name
                            select b;

            }
        }

    }
}
