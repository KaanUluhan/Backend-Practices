using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
   public class BusinessRules
    {   
        public static IResult Run(params IResult[] logics)     //siz params verdiğiniz zaman run içerisine istediğiniz kadar ıresult verebiliyosunuz parametre olarak
        {
            foreach (var logic in logics)   //logicsleri gez
            {
                if (!logic.Success)
                {
                    return logic;     //başarısız olanı business a şu logic hatalı diye haber gönderiyoruz
                }
            }
                   return null;
        }
    }
}
