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
    public class EfModelDal : EfEntityRepositoryBase<Model, ReCapContext>, IModelDal
    {
        public List<ModelDetailDto> GetAllModelDetails(Expression<Func<ModelDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from model in context.Models
                              join brand in context.Brands on model.BrandId equals brand.Id
                              select new ModelDetailDto
                              {
                                  Id = model.Id,
                                  BrandName = brand.Name,
                                  Name = model.Name
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public ModelDetailDto GetModelDetails(Expression<Func<ModelDetailDto, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from model in context.Models
                              join brand in context.Brands on model.BrandId equals brand.Id
                              select new ModelDetailDto
                              {
                                  Id = model.Id,
                                  BrandName = brand.Name,
                                  Name = model.Name
                              });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
