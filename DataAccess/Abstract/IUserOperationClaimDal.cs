using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>
    {
        List<UserOperationClaimDetailDto> GetAllUserOperationClaimDetails(Expression<Func<UserOperationClaimDetailDto, bool>> filter = null);
        UserOperationClaimDetailDto GetUserOperationClaimDetails(Expression<Func<UserOperationClaimDetailDto, bool>> filter);
    }
}
