using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserOperationClaimManager : IUserOperationClaimService
    {
        private readonly IUserOperationClaimDal _userOperationClaimDal;

        public UserOperationClaimManager(IUserOperationClaimDal userOperationClaimDal)
        {
            _userOperationClaimDal = userOperationClaimDal;
        }

        [CacheRemoveAspect("IUserOperationClaimService.GetAll")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Add(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Add(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimCreated);
        }

        [CacheRemoveAspect("IUserOperationClaimService.Get")]
        public IResult Delete(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Delete(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimDeleted);
        }

        [CacheAspect]
        public IDataResult<List<UserOperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<UserOperationClaim>>(_userOperationClaimDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<UserOperationClaim> GetById(int id)
        {
            return new SuccessDataResult<UserOperationClaim>(_userOperationClaimDal.Get(c => c.Id == id));
        }

        [CacheRemoveAspect("IUserOperationClaimService.Get")]
        [ValidationAspect(typeof(UserOperationClaimValidator))]
        public IResult Update(UserOperationClaim userOperationClaim)
        {
            _userOperationClaimDal.Update(userOperationClaim);
            return new SuccessResult(Messages.UserOperationClaimUpdated);
        }



        [CacheAspect]
        public IDataResult<List<UserOperationClaimDetailDto>> GetAllUserOperationClaimDetails()
        {
            return new SuccessDataResult<List<UserOperationClaimDetailDto>>(_userOperationClaimDal.GetAllUserOperationClaimDetails());
        }
        public IDataResult<UserOperationClaimDetailDto> GetUserOperationClaimDetailsById(int id)
        {
            return new SuccessDataResult<UserOperationClaimDetailDto>(_userOperationClaimDal.GetUserOperationClaimDetails(m => m.Id == id));
        }
    }
}
