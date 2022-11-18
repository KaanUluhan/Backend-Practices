using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>      //sen bir resultsun sonra implement için uyarı aldık
    {
        

        public DataResult(T data, bool success, string message):base(success,message)    //base e success ve message ı yolla bi daha o kodu yazmaya gerek kalmıyo
        {
            Data = data;   //datayı set ettik
        }
        public DataResult(T data, bool success):base(success)
        {
            Data = data;
        }
        
        public T Data { get; }
    }
}
