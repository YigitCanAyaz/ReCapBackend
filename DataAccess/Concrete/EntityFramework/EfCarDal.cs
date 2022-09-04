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
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from car in context.Cars
                              join color in context.Colors on car.ColorId equals color.Id
                              join carModel in context.Models on car.ModelId equals carModel.Id

                              from brandModel in context.Models
                              join brand in context.Brands on brandModel.BrandId equals brand.Id
                              select new CarDetailDto
                             {
                                 Id = car.Id,
                                 BrandName = brand.Name,
                                 ModelName = carModel.Name,
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
