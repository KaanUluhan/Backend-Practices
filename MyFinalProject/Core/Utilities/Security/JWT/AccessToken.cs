using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken               //access token erişim anahtarı 
    {
        public string token { get; set; }
        public object Token { get; internal set; }
        public DateTime Expiration { get; set; }
    }
}
