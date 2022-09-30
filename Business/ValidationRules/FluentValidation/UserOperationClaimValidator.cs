using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace Business.ValidationRules.FluentValidation
{
    public class UserOperationClaimValidator : AbstractValidator<UserOperationClaim>
    {
        public UserOperationClaimValidator()
        {
            // RuleFor().();
            RuleFor(u => u.UserId).NotEmpty();
            RuleFor(u => u.OperationClaimId).NotEmpty();
        }
    }
}
