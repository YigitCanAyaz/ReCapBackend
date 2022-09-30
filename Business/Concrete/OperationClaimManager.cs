using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants.Messages;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        private readonly IOperationClaimDal _OperationClaimDal;

        public OperationClaimManager(IOperationClaimDal OperationClaimDal)
        {
            _OperationClaimDal = OperationClaimDal;
        }

        [CacheRemoveAspect("IOperationClaimService.GetAll")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim OperationClaim)
        {
            _OperationClaimDal.Add(OperationClaim);
            return new SuccessResult(Messages.OperationClaimCreated);
        }

        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Delete(OperationClaim OperationClaim)
        {
            _OperationClaimDal.Delete(OperationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_OperationClaimDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_OperationClaimDal.Get(c => c.Id == id));
        }

        [CacheRemoveAspect("IOperationClaimService.Get")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim OperationClaim)
        {
            _OperationClaimDal.Update(OperationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }
    }
}
