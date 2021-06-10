using NawazDemoWebApi.Core.Domain;
using NawazDemoWebApi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NawazDemoWebApi.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {
        private CustomerContext _ctx;

        public CustomerRepository(CustomerContext _ctx)
            :base(_ctx)
        {
            // TODO: Complete member  
            this._ctx = _ctx;

        }

        public CustomerContext CustomerContext
        {
            get { return Context as CustomerContext; }
        }

    }
}