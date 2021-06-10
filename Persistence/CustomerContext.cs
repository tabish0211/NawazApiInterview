using NawazDemoWebApi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NawazDemoWebApi.Persistence
{
    public class CustomerContext : DbContext
    {
        public CustomerContext()
            : base("name=constr")
        {

        }

        //register entity
        public DbSet<Customer> Customers { get; set; }
    }
}