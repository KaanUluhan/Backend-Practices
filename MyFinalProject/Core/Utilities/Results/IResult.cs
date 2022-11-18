using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç
   public interface IResult  //amaç uygulamamızı kullanacakları doğru yönlendirmek
    {    // !!!! get okumak için ,set yazmak için

        bool Success { get; }
        string Message { get; }
    }
}
