using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetAllClaims(User user);
        IDataResult<List<UserForInfoDto>> GetAll();
        IDataResult<UserForInfoDto> GetById(int id);
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
    }
}
