using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using MyCompany.Domain;
using MyCompany.EF;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ProductContext())
            {
                // Create and save a new Product 
                Console.Write("Enter a name for a new product: ");
                var name = Console.ReadLine();

                var product = new Product { Name = name, Category = "Category" };
                db.Products.Add(product);
                db.SaveChanges();

                // Display all Products from the database 
                var query = from b in db.Products
                            orderby b.Name
                            select b;

                Console.WriteLine("All products in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            } 
        }
    }


}
