using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;


namespace SomeClass.Domain
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(typeof(Product).Assembly);

            // new SchemaExport(cfg).Execute(false, true, false, false);
            SchemaExport schemaExport = new SchemaExport(cfg);
            schemaExport.Execute(false, true, false);
        }
    }
}
