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
        public List<CustomerDetailDto> GetAllCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from customer in context.Customers
                              join user in context.Users on customer.UserId equals user.Id
                              select new CustomerDetailDto
                              {
                                  Id = customer.Id,
                                  UserId = user.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  CompanyName = customer.CompanyName
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CustomerDetailDto GetCustomerDetails(Expression<Func<CustomerDetailDto, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from customer in context.Customers
                    join user in context.Users on customer.UserId equals user.Id
                    select new CustomerDetailDto
                    {
                        Id = customer.Id,
                        UserId = user.Id,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        CompanyName = customer.CompanyName
                    });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
