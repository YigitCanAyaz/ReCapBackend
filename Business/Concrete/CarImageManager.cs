using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carDal;

        public CarImageManager(ICarImageDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(CarImage carImage)
        {
            _carDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            _carDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carDal.Get(c => c.Id == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carDal.Update(carImage);
            return new SuccessResult();
        }
    }
}
