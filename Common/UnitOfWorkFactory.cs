using NawazDemoWebApi.Core;
using NawazDemoWebApi.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NawazDemoWebApi.Common
{
    public static class UnitOfWorkFactory
    {

        public static IUnitOfWork GetUnitOfWork()
        {

            return new UnitOfWork(new CustomerContext());
        }
    }
}