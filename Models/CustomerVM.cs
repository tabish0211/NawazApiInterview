using NawazDemoWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NawazDemoWebApi.Controllers
{
    public class CustomerVM
    {
        public IList<Customer> customers { get; set; }
    }
}
