using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetAllClaims(User user);

        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByMail(string email);
        IResult Add(User user);
    }
}
