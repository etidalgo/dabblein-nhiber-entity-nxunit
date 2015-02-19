using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using MyCompany.Domain;
using MyCompany.Repositories;
using NHibernate;

namespace MyCompany.Tests
{
    [TestFixture]
    public class ProductRepository_Fixture
    {
        private ISessionFactory _sessionFactory;
        private Configuration _configuration;

        private readonly Product[] _products = new[]
                 {
                     new Product {Name = "Melon", Category = "Fruits"},
                     new Product {Name = "Pear", Category = "Fruits"},
                     new Product {Name = "Milk", Category = "Beverages"},
                     new Product {Name = "Coca Cola", Category = "Beverages"},
                     new Product {Name = "Pepsi Cola", Category = "Beverages"},
                 };

        private void CreateInitialData()
        {
            using (ISession session = _sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                foreach (var product in _products)
                    session.Save(product);
                transaction.Commit();
            }
        }

        [SetUp]
        public void SetupContext()
        {
            new SchemaExport(_configuration).Execute(false, true, false);
            CreateInitialData();
        }
        
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            _configuration = new Configuration();
            _configuration.Configure();
            _configuration.AddAssembly(typeof(Product).Assembly);
            _sessionFactory = _configuration.BuildSessionFactory();
        }

        [Test]
        public void Can_add_new_product()
        {
            var product = new Product { Name = "Apple", Category = "Fruits" };
            IProductRepository repository = new ProductRepository();
            repository.Add(product);

            // use session to try to load the product
            using (ISession session = _sessionFactory.OpenSession())
            {
                var fromDb = session.Get<Product>(product.Id);
                // Test that the product was successfully inserted
                Assert.IsNotNull(fromDb);
                Assert.AreNotSame(product, fromDb);
                Assert.AreEqual(product.Name, fromDb.Name);
                Assert.AreEqual(product.Category, fromDb.Category);
            }
        }

    }
}
