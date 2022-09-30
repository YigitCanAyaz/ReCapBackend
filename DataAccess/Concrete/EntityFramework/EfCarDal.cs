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
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from modelColor in context.ModelColors
                              join model in context.Models on modelColor.ModelId equals model.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              join car in context.Cars on modelColor.ModelId equals car.ModelId
                              select new CarDetailDto
                              {
                                  Id = car.Id,
                                  BrandId = brand.Id,
                                  BrandName = brand.Name,
                                  ModelId = model.Id,
                                  ModelName = model.Name,
                                  Description = car.Description,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = model.Year,
                                  ColorName = (from color in context.Colors where modelColor.ColorId == color.Id select color.Name).ToList(),
                                  ImagePath = (from carImage in context.CarImages where car.Id == carImage.CarId select carImage.ImagePath).ToList(),
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from modelColor in context.ModelColors
                              join model in context.Models on modelColor.ModelId equals model.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              join car in context.Cars on modelColor.ModelId equals car.ModelId
                              select new CarDetailDto
                              {
                                  Id = car.Id,
                                  BrandId = brand.Id,
                                  BrandName = brand.Name,
                                  ModelId = model.Id,
                                  ModelName = model.Name,
                                  Description = car.Description,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = model.Year,
                                  ColorName = (from color in context.Colors where modelColor.ColorId == color.Id select color.Name).ToList(),
                                  ImagePath = (from carImage in context.CarImages where car.Id == carImage.CarId select carImage.ImagePath).ToList()
                              });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
