using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public interface ITokenHelper          //ierleyen zamanlarda başka bir teknik kullanmak istersek vs. diye oluşturduk
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);         //kullanıcı adı şifre girdi butona bastı createtoken çalıştı doğruysa veritabanına gitti kullanıcının claimleri buldu orada JWT üretti onları buraya verecek 
        
    }
}
