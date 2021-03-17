using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
  public static  class ValidationTool
    {
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);//gelen validatorun örneğin ProductValidator bunu doğrula
            if (!result.IsValid)//doğrulamaya uymuyorsa
            {
                throw new ValidationException(result.Errors);//hata fırlat
            }
        }
    }
}
