using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        private readonly IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        [CacheRemoveAspect("IModelService.GetAll")]
        [ValidationAspect(typeof(ModelValidator))]
        public IResult Add(Model model)
        {
            _modelDal.Add(model);
            return new SuccessResult();
        }

        [CacheRemoveAspect("IModelService.Get")]
        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult();
        }

        [CacheAspect]
        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(b => b.Id == id));
        }

        [CacheRemoveAspect("IModelService.Get")]
        [ValidationAspect(typeof(ModelValidator))]
        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult();
        }
    }
}
