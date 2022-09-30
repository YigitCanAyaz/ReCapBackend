using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfModelColorDal : EfEntityRepositoryBase<ModelColor, ReCapContext>, IModelColorDal
    {
        public List<ModelColorDetailDto> GetAllModelColorDetails(Expression<Func<ModelColorDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from modelColor in context.ModelColors
                              join model in context.Models on modelColor.ModelId equals model.Id
                              join color in context.Colors on modelColor.ColorId equals color.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              select new ModelColorDetailDto
                              {
                                  Id = modelColor.Id,
                                  BrandId = brand.Id,
                                  BrandName = brand.Name,
                                  ModelId = model.Id,
                                  ModelName = model.Name,
                                  ColorId = color.Id,
                                  ColorName = color.Name,
                                  ModelYear = model.Year
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public ModelColorDetailDto GetModelColorDetails(Expression<Func<ModelColorDetailDto, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from modelColor in context.ModelColors
                              join model in context.Models on modelColor.ModelId equals model.Id
                              join color in context.Colors on modelColor.ColorId equals color.Id
                              join brand in context.Brands on model.BrandId equals brand.Id
                              select new ModelColorDetailDto
                              {
                                  Id = modelColor.Id,
                                  BrandId = brand.Id,
                                  BrandName = brand.Name,
                                  ModelId = model.Id,
                                  ModelName = model.Name,
                                  ColorId = color.Id,
                                  ColorName = color.Name,
                                  ModelYear = model.Year
                              });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
