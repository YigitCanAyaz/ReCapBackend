using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IModelColorDal : IEntityRepository<ModelColor>
    {
        List<ModelColorDetailDto> GetAllModelColorDetails(Expression<Func<ModelColorDetailDto, bool>> filter = null);
        ModelColorDetailDto GetModelColorDetails(Expression<Func<ModelColorDetailDto, bool>> filter);
    }
}
