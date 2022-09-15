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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result =
                    (from rental in context.Rentals
                     join car in context.Cars on rental.CarId equals car.Id
                     join model in context.Models on car.ModelId equals model.Id
                     join brand in context.Brands on model.BrandId equals brand.Id
                     join customer in context.Customers on rental.CustomerId equals customer.Id
                     join user in context.Users on customer.UserId equals user.Id
                     select new RentalDetailDto
                     {
                         Id = rental.Id,
                         ModelName = model.Name,
                         BrandName = brand.Name,
                         ModelYear = car.ModelYear,
                         FirstName = user.FirstName,
                         LastName = user.LastName,
                         RentDate = rental.RentDate,
                         ReturnDate = rental.ReturnDate
                     });

                return result.ToList();
            }
        }

        public RentalDetailDto GetRentalDetailsById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result =
                    (from rental in context.Rentals
                     join car in context.Cars on rental.CarId equals car.Id
                     join model in context.Models on car.ModelId equals model.Id
                     join brand in context.Brands on model.BrandId equals brand.Id
                     join customer in context.Customers on rental.CustomerId equals customer.Id
                     join user in context.Users on customer.UserId equals user.Id
                     where rental.Id == id
                     select new RentalDetailDto
                     {
                         Id = rental.Id,
                         ModelName = model.Name,
                         BrandName = brand.Name,
                         ModelYear = car.ModelYear,
                         FirstName = user.FirstName,
                         LastName = user.LastName,
                         RentDate = rental.RentDate,
                         ReturnDate = rental.ReturnDate
                     });

                return result.SingleOrDefault();
            }
        }
    }
}
