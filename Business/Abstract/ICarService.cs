using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAllCarsByModelId(int modelId);
        IDataResult<List<Car>> GetAllCarsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<CarDetailDto> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailsByModelId(int modelId);
        IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandIdColorId(int brandId, int colorId);
    }
}
