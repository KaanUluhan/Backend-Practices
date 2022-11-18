using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
   public static class ValidationTool               //tek seferde kullanılacğı için static
    {
        public static void Validate(IValidator validator,object entity)    //ben buraya netity dto ekleyebilirim hepsinin basesi object o yüzden yazdım
        {
            var context = new ValidationContext<Object>(entity);         //product/değişti object entity yazdık) için doğrulama yapıcaz diyoruz
            var result = validator.Validate(context);                //validatör ile (orada yazdığımız kurallar için) doğrula
            if (!result.IsValid)                                            //sonuç geçerli deilse hata fırlar
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
