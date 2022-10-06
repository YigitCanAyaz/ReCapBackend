using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<Model> GetById(int id);
        IDataResult<List<Model>> GetAll();
        IDataResult<List<Model>> GetAllModelsByBrandId(int brandId);
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);

        IDataResult<List<ModelDetailDto>> GetAllModelDetails();
        IDataResult<ModelDetailDto> GetModelDetailsById(int id);
        IDataResult<int> GetAllModelLength();
    }
}
