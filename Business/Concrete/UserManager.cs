using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Business.BusinessAspects.Autofac;
using Business.Constants.Messages;
using Entities.DTOs;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IDataResult<List<OperationClaim>> GetAllClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetAllClaims(user));
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserCreated);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        //[SecuredOperation("admin")]
        public IDataResult<List<UserForInfoDto>> GetAll()
        {
            return new SuccessDataResult<List<UserForInfoDto>>(_userDal.GetAllUserDetails());
        }

        public IDataResult<UserForInfoDto> GetById(int id)
        {
            return new SuccessDataResult<UserForInfoDto>(_userDal.GetUserDetails(u => u.Id == id));
        }

    }
}
