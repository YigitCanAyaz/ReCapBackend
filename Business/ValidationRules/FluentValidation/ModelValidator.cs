using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            // RuleFor().();
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
