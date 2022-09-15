using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
        List<ModelDetailDto> GetAllModelDetails();
        ModelDetailDto GetModelDetailsById(int id);
    }
}
