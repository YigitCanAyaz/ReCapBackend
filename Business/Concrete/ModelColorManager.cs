using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class ModelColorManager : IModelColorService
    {
        private readonly IModelColorDal _modelColorDal;

        public ModelColorManager(IModelColorDal modelColorDal)
        {
            _modelColorDal = modelColorDal;
        }

        [CacheRemoveAspect("IModelColorService.GetAll")]
        [ValidationAspect(typeof(ModelColorValidator))]
        public IResult Add(ModelColor modelColor)
        {
            _modelColorDal.Add(modelColor);
            return new SuccessResult(Messages.ModelColorCreated);
        }

        [CacheRemoveAspect("IModelColorService.Get")]
        public IResult Delete(ModelColor modelColor)
        {
            _modelColorDal.Delete(modelColor);
            return new SuccessResult(Messages.ModelColorDeleted);
        }

        [CacheAspect]
        public IDataResult<List<ModelColor>> GetAll()
        {
            return new SuccessDataResult<List<ModelColor>>(_modelColorDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<ModelColor> GetById(int id)
        {
            return new SuccessDataResult<ModelColor>(_modelColorDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IModelColorService.Get")]
        [ValidationAspect(typeof(ModelColorValidator))]
        public IResult Update(ModelColor modelColor)
        {
            _modelColorDal.Update(modelColor);
            return new SuccessResult(Messages.ModelColorUpdated);
        }
    }
}