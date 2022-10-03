using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carDal)
        {
            _carImageDal = carDal;
        }

        [CacheRemoveAspect("ICarImageService.GetAll")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {

            var businessResult = BusinessRules.Run(CheckIfCarImageLimitExceeded(carImage.Id));

            if (businessResult != null)
            {
                return businessResult;
            }

            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;

            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageCreated);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var result = FileHelper.Delete(carImage.ImagePath);

            if (!result.Success)
            {
                return new ErrorResult();
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckIfCarHasAnyImage(carId));

            if (result != null)
            {
                switch (result.Message)
                {
                    case Messages.CarImageNotExist:
                        return SetDefaultPhoto(carId);

                    default:
                        return new ErrorDataResult<List<CarImage>>(result.Message);
                }
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var result = BusinessRules.Run(/*CheckIfCarIdIsSame(carImage.Id, carImage.CarId)*/);

            if (result != null)
            {
                return result;
            }

            var imageResult = FileHelper.Update(file, carImage.ImagePath);

            if (!imageResult.Success)
            {
                return imageResult;
            }

            carImage.ImagePath = imageResult.Message;
            carImage.Date = DateTime.Now;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        [CacheAspect]
        public IDataResult<List<CarImageDetailDto>> GetAllCarImageDetails()
        {
            return new SuccessDataResult<List<CarImageDetailDto>>(_carImageDal.GetAllCarImageDetails());
        }
        public IDataResult<CarImageDetailDto> GetCarImageDetailsById(int id)
        {
            return new SuccessDataResult<CarImageDetailDto>(_carImageDal.GetCarImageDetails(m => m.Id == id));
        }

        /********************************** PRIVATE METHODS ********************************** */

        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;

            if (result >= 5)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarHasAnyImage(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();

            if (!result)
            {
                return new ErrorResult(Messages.CarImageNotExist);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCarIdIsSame(int id, int carId)
        {
            var result = _carImageDal.Get(c => c.Id == id).CarId;

            if (result != carId)
            {
                return new ErrorResult();
            }

            return new SuccessResult();
        }

        private static IDataResult<List<CarImage>> SetDefaultPhoto(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(new List<CarImage>{new CarImage
            {
                CarId = carId,
                Date = DateTime.Now,
                ImagePath = @"/Images/default.png"
            }});
        }

    }
}
