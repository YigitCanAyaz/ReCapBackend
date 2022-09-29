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
using Entities.DTOs;

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
            return new SuccessResult(Messages.ModelCreated);
        }

        [CacheRemoveAspect("IModelService.Get")]
        public IResult Delete(Model model)
        {
            _modelDal.Delete(model);
            return new SuccessResult(Messages.ModelDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<List<ModelDetailDto>> GetAllModelDetails()
        {
            return new SuccessDataResult<List<ModelDetailDto>>(_modelDal.GetAllModelDetails());
        }

        [CacheAspect]
        public IDataResult<List<Model>> GetAllModelsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(m => m.BrandId == brandId));
        }

        [CacheAspect]
        public IDataResult<Model> GetById(int id)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(b => b.Id == id));
        }

        public IDataResult<ModelDetailDto> GetModelDetailsById(int id)
        {
            return new SuccessDataResult<ModelDetailDto>(_modelDal.GetModelDetails(m => m.Id == id));
        }

        [CacheRemoveAspect("IModelService.Get")]
        [ValidationAspect(typeof(ModelValidator))]
        public IResult Update(Model model)
        {
            _modelDal.Update(model);
            return new SuccessResult(Messages.ModelUpdated);
        }
    }
}
