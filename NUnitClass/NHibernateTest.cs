using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using MyCompany.Domain;


namespace MyCompany.Tests
{
    [TestFixture]
    public class NHibernateTest
    {
        [Test]
        public void Can_generate_schema()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            // new SchemaExport(cfg).Execute(false, true, false, false);
            new SchemaExport(cfg).Execute(false, true, false);
        }
    }
}
