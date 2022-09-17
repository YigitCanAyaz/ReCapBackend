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
            return new SuccessResult();
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            Thread.Sleep(10000);
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
            var result = _carDal.GetAllCarDetails();

            // ayrı private metoda al

            foreach (var carDetail in result)
            {
                if (carDetail.ImagePath.Count == 0)
                {
                    carDetail.ImagePath = new List<string>
                    {
                        @"/Images/default.png"
                    };
                }
            }

            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarDetailsById(int id)
        {
            var result = _carDal.GetCarDetails(c => c.Id == id);

            if (result.ImagePath.Count == 0)
            {
                result.ImagePath = new List<string>
                {
                    @"/Images/default.png"
                };
            }

            return new SuccessDataResult<CarDetailDto>(result);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllCarsByModelId(int modelId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelId == modelId));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();
        }
    }
}
