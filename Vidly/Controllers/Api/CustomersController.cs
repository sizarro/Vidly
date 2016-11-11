using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext context;

        public CustomersController()
        {
            context = new ApplicationDbContext();
        }

        // GET: api/Customers
        public IHttpActionResult GetCustomers()
        {
            var customers = context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customers);
        }

        // GET: api/Customers/5
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST: api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            context.Customers.Add(customer);
            context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT: api/Customers/5
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, customerInDb);

            context.SaveChanges();

            return Ok();
        }

        // DELETE: api/Customers/5
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            context.Customers.Remove(customerInDb);
            context.SaveChanges();

            return Ok();
        }


        //// POST: api/Customers
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Customers/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Customers/5
        //public void Delete(int id)
        //{
        //}
    }
}
