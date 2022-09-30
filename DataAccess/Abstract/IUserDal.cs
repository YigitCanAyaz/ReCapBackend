using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetAllClaims(User user);
        List<UserForInfoDto> GetAllUserDetails(Expression<Func<UserForInfoDto, bool>> filter = null);
        UserForInfoDto GetUserDetails(Expression<Func<UserForInfoDto, bool>> filter);
    }
}
