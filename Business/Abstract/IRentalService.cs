using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<Rental> GetById(int id);
        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult Return(Rental rental);

        IResult IsCarAvailable(int carId);

        IDataResult<List<RentalDetailDto>> GetAllRentalDetails();
        IDataResult<RentalDetailDto> GetRentalDetailsById(int id);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetailsByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetAllRentalDetailsByCustomerId(int customerId);
        IDataResult<int> GetAllRentalLength();
    }
}
