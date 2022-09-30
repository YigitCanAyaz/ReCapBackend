using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [CacheRemoveAspect("ICarService.GetAll")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.CarCreated);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails());
        }

        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarDetailsById(int id)
        {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetails(c => c.Id == id));
        }

        //[CacheAspect]
        //public IDataResult<List<Car>> GetAllCarsByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        //}

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.BrandId == brandId));
        }

        //[CacheAspect]
        //public IDataResult<List<CarDetailDto>> GetAllCarDetailsByColorId(int colorId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.ColorId == colorId));
        //}

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarDetailsByModelId(int modelId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.ModelId == modelId));
        }

        //[CacheAspect]
        //public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandIdColorId(int brandId, int colorId)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.BrandId == brandId && c.ColorId == colorId));
        //}

        //[CacheAspect]
        //public IDataResult<List<CarDetailDto>> GetAllCarDetailsByBrandIdColorIdMinDailyPriceMaxDailyPrice(int brandId, int colorId, int minDailyPrice, int maxDailyPrice)
        //{
        //    return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetAllCarDetails(c => c.BrandId == brandId && c.ColorId == colorId && c.DailyPrice >= minDailyPrice && c.DailyPrice <= maxDailyPrice));
        //}

        // *********************************

    }
}
