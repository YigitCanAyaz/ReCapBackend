using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarImageDal : IEntityRepository<CarImage>
    {
        List<CarImageDetailDto> GetAllCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter = null);
        CarImageDetailDto GetCarImageDetails(Expression<Func<CarImageDetailDto, bool>> filter);
    }
}
