using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetAllCustomerDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from customer in context.Customers
                              join user in context.Users on customer.UserId equals user.Id
                              select new CustomerDetailDto
                              {
                                  Id = customer.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  CompanyName = customer.CompanyName
                              });

                return result.ToList();
            }
        }

        public CustomerDetailDto GetCustomerDetailsById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from customer in context.Customers
                              join user in context.Users on customer.UserId equals user.Id
                              where customer.Id == id
                              select new CustomerDetailDto
                              {
                                  Id = customer.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  CompanyName = customer.CompanyName
                              });

                return result.SingleOrDefault();
            }
        }
    }
}
