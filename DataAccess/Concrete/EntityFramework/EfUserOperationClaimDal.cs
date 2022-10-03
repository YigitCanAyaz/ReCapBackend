using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, ReCapContext>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDetailDto> GetAllUserOperationClaimDetails(Expression<Func<UserOperationClaimDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from userOperationClaim in context.UserOperationClaims
                              join user in context.Users on userOperationClaim.UserId equals user.Id
                              join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                              where user.Status == true
                              select new UserOperationClaimDetailDto
                              {
                                  Id = userOperationClaim.Id,
                                  UserId = user.Id,
                                  OperationClaimId = operationClaim.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  OperationClaimName = operationClaim.Name,
                              });

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public UserOperationClaimDetailDto GetUserOperationClaimDetails(Expression<Func<UserOperationClaimDetailDto, bool>> filter)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = (from userOperationClaim in context.UserOperationClaims
                              join user in context.Users on userOperationClaim.UserId equals user.Id
                              join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                              where user.Status == true
                              select new UserOperationClaimDetailDto
                              {
                                  Id = userOperationClaim.Id,
                                  UserId = user.Id,
                                  OperationClaimId = operationClaim.Id,
                                  FirstName = user.FirstName,
                                  LastName = user.LastName,
                                  Email = user.Email,
                                  OperationClaimName = operationClaim.Name,
                              });

                return result.Where(filter).SingleOrDefault();
            }
        }
    }
}
