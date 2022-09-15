using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public CarDetailDto GetCarDetailsById(int carId)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from car in context.Cars
                              join color in context.Colors on car.ColorId equals color.Id
                              join model in context.Models on car.ModelId equals model.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              where car.Id == carId
                              select new CarDetailDto
                              {
                                  Id = car.Id,
                                  BrandName = brand.Name,
                                  ModelName = model.Name,
                                  ColorName = color.Name,
                                  Description = car.Description,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                              });

                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from car in context.Cars
                              join color in context.Colors on car.ColorId equals color.Id
                              join model in context.Models on car.ModelId equals model.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              select new CarDetailDto
                              {
                                  Id = car.Id,
                                  BrandName = brand.Name,
                                  ModelName = model.Name,
                                  ColorName = color.Name,
                                  Description = car.Description,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = car.ModelYear,
                              });

                return result.ToList();
            }
        }

    }
}
