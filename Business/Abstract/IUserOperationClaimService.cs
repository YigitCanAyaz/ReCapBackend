using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<UserOperationClaim> GetById(int id);
        IDataResult<List<UserOperationClaim>> GetAll();
        IResult Add(UserOperationClaim userOperationClaim);
        IResult Update(UserOperationClaim userOperationClaim);
        IResult Delete(UserOperationClaim userOperationClaim);

        IDataResult<List<UserOperationClaimDetailDto>> GetAllUserOperationClaimDetails();
        IDataResult<UserOperationClaimDetailDto> GetUserOperationClaimDetailsById(int id);
    }
}
