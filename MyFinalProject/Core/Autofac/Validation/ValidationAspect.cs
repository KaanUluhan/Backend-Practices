using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Autofac.Validation
{
    public class ValidationAspect : MethodInterception  //Aspect sen neresinde istiyorsan orada çalışır öncesi sonrası vs   //sen bir methodınterceptionsun
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);    //invocation method demek validatorün tipine eşit olan parametreleri bul
            foreach (var entity in entities)                                                //her birini tek tek gez 
            {
                ValidationTool.Validate(validator, entity);                             //validationtool u kullanarak validate et
            }
        }
    }
}
