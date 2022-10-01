using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IModelColorService
    {
        IDataResult<ModelColor> GetById(int id);
        IDataResult<List<ModelColor>> GetAll();
        IResult Add(ModelColor modelColor);
        IResult Update(ModelColor modelColor);
        IResult Delete(ModelColor modelColor);

        IDataResult<List<ModelColorDetailDto>> GetAllModelColorDetails();
        IDataResult<ModelColorDetailDto> GetModelColorDetailsById(int id);
    }
}
