using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using A.Blog.Entity;
using System.Diagnostics;
using System.Linq;

namespace A.Blog.Data.Test
{
    [TestClass]
    public class ConsumerTest
    {
        private IRepository _repository;

        [TestInitialize]
        public void Initialise() {
            _repository = new BlogRepository();
        }

        [TestMethod]
        public void Query_AllCustomers_NoException()
        {
            var list = _repository.All<Customer>();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name : {0}", item.CompanyName);
            }

        }

        [TestMethod]
        public void Query_AllCustomersIncludingOrders_NoException()
        {
            var list = _repository.AllIncluding<Customer>(p => p.Orders).ToList();

            foreach (var item in list)
            {
                Trace.TraceInformation("Company Name : {0}", item.CompanyName);
            }

        }
    }
}
