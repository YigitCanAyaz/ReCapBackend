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

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOperationClaimService.GetAll")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimCreated);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Delete(OperationClaim OperationClaim)
        {
            _operationClaimDal.Delete(OperationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        [SecuredOperation("admin")]
        [CacheAspect]
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(c => c.Id == id));
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IOperationClaimService.Get")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim OperationClaim)
        {
            _operationClaimDal.Update(OperationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }
    }
}
