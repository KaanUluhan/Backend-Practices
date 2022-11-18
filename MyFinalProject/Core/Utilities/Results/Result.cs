using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult    //ampulle çözdük soyut  somut  result-ıresult
    {
  

        public Result(bool success, string message):this(success)   // true ve ürün eklendi için bu tarzı kurduk  this, resultu kasteder bu demek  
        {
            Message = message;
          
        }
        public Result(bool success)   // true  için bu tarzı kurduk
        {
          
            Success = success;
        }

        public bool Success { get ;}

        public string Message { get; } 
    }
}
