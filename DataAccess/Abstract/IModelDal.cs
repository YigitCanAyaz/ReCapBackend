using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
        List<ModelDetailDto> GetAllModelDetails(Expression<Func<ModelDetailDto, bool>> filter = null);
        ModelDetailDto GetModelDetails(Expression<Func<ModelDetailDto, bool>> filter);
    }
}
