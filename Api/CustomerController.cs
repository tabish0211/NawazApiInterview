using NawazDemoWebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NawazDemoWebApi.Models;
using NawazDemoWebApi.Controllers;
using NawazDemoWebApi.Core;

namespace NawazDemoWebApi.Api
{
    public class CustomerController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork = Common.UnitOfWorkFactory.GetUnitOfWork();
        // GET api/<controller>
        public HttpResponseMessage Get()
        {

            var result = _unitOfWork.Customers.GetAll();
            var Response = new
            {

                Status = true,
                Data = result,
                StatusCode = HttpStatusCode.OK,
                ErrorMessage = "",
                ErrorCode = ""

            };            
            return Request.CreateResponse(HttpStatusCode.OK, Response, "application/json");

        }

        // GET api/Customer/5
        public HttpResponseMessage Get(int id)
        {
            CustomerContext contxt = new CustomerContext();
            var result = contxt.Customers.Where(c => c.Id == id).SingleOrDefault();

            var Response = new
            {

                Status = true,
                Data = result,
                StatusCode = HttpStatusCode.OK,
                ErrorMessage = "",
                ErrorCode = ""

            };
            contxt.Dispose();

            return Request.CreateResponse(HttpStatusCode.OK, Response, "application/json");
            
        }

        // POST api/Customer
        public void Post([FromBody]CustomerVM customers)
        {
            CustomerContext contxt = new CustomerContext(); 
           
           contxt.Customers.AddRange(customers.customers);
           // //contxt.Customers.Add(customer);
            contxt.SaveChanges();
            contxt.Dispose();

        }

        // PUT api/Customer/1
        public void Put(int id, [FromBody]Customer customer)
        {
            CustomerContext contxt = new CustomerContext();
            var result = contxt.Customers.Where(c => c.Id == id).SingleOrDefault();
            if (result != null)
            {
                result.Name = customer.Name;
                result.PhoneNo = customer.PhoneNo;

                contxt.SaveChanges();
               
            }
            contxt.Dispose();
        }

        // DELETE api/Customer/1
        public void Delete(int id)
        {
            //sample check-in
            CustomerContext contxt = new CustomerContext();
            var result = contxt.Customers.Where(c => c.Id == id).SingleOrDefault();
            if (result != null)
            {
                contxt.Customers.Remove(result);
                contxt.SaveChanges();

            }
            contxt.Dispose();
        }
    }
}