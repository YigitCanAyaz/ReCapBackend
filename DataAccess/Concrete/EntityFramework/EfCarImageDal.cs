using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, ReCapContext>, ICarImageDal
    {
        public List<CarImageDetailDto> GetAllCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from modelColor in context.ModelColors
                              join color in context.Colors on modelColor.ColorId equals color.Id
                              join model in context.Models on modelColor.ModelId equals model.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              join car in context.Cars on modelColor.Id equals car.ModelColorId
                              join carImage in context.CarImages on car.Id equals carImage.Id
                              select new CarImageDetailDto
                              {
                                  Id = carImage.Id,
                                  CarId = car.Id,
                                  BrandName = brand.Name,
                                  ModelName = model.Name,
                                  ColorName = color.Name,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = model.Year,
                                  ImagePath = carImage.ImagePath,
                                  Date = carImage.Date
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public CarImageDetailDto GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from modelColor in context.ModelColors
                              join color in context.Colors on modelColor.ColorId equals color.Id
                              join model in context.Models on modelColor.ModelId equals model.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              join car in context.Cars on modelColor.Id equals car.ModelColorId
                              join carImage in context.CarImages on car.Id equals carImage.Id
                              select new CarImageDetailDto
                              {
                                  Id = carImage.Id,
                                  CarId = car.Id,
                                  BrandName = brand.Name,
                                  ModelName = model.Name,
                                  ColorName = color.Name,
                                  DailyPrice = car.DailyPrice,
                                  ModelYear = model.Year,
                                  ImagePath = carImage.ImagePath,
                                  Date = carImage.Date
                              });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
