using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
    }
}
