using NawazDemoWebApi.Core;
using NawazDemoWebApi.Core.IRepositories;
using NawazDemoWebApi.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NawazDemoWebApi.Persistence
{
    public class UnitOfWork :IUnitOfWork
    {

        private readonly CustomerContext _ctx;
        public UnitOfWork(CustomerContext ctxt)
        {
            _ctx = ctxt;

            Customers = new CustomerRepository(_ctx);
        }

        public ICustomerRepository Customers { get; private set; }

        public int Complete()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}