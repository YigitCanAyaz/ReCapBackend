using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelColorValidator : AbstractValidator<ModelColor>
    {
        public ModelColorValidator()
        {
            // RuleFor().();
            RuleFor(m => m.ModelId).NotEmpty();
            RuleFor(m => m.ColorId).NotEmpty();
        }
    }
}
