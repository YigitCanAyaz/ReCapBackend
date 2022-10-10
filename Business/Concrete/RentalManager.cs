using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Entities.DTOs;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        [CacheRemoveAspect("IRentalService.GetAll")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarHasBeenReturned(rental.Id));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);

            return new SuccessResult(Messages.RentalCreated);
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<int> GetAllRentalLength()
        {
            return new SuccessDataResult<int>(_rentalDal.GetAll().Count);
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails());
        }

        [CacheAspect]
        public IDataResult<RentalDetailDto> GetRentalDetailsById(int id)
        {
            return new SuccessDataResult<RentalDetailDto>(_rentalDal.GetRentalDetails(r => r.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetailsByCarId(int carId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails(r => r.CarId == carId));
        }

        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetailsByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetAllRentalDetails(r => r.CustomerId == customerId));
        }

        [CacheAspect]
        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Return(Rental rental)
        {
            rental.ReturnDate = DateTime.Now;

            Update(rental);

            return new SuccessResult();
        }

        [CacheRemoveAspect("IRentalService.Get")]
        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        /********************************** PRIVATE METHODS ********************************** */

        private IResult CheckIfCarHasBeenReturned(int id)
        {
            var result = _rentalDal.GetAll(r => r.CarId == id);

            foreach (var car in result)
            {
                if (car.ReturnDate == DateTime.MinValue)
                {
                    return new ErrorResult();
                }
            }

            return new SuccessResult();
        }
    }
}
