using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {   
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())                       //hmac kriptografi sınıfında kullandıımız sınıfa denk geliyor ezberlemeye gerek yok buraları
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));         //bu kodlar verdiğimiz password değerine göre salt ve hash değerini oluşturmaya yarıyor
            }
        }

        public static bool VerifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())                       //hmac kriptografi sınıfında kullandıımız sınıfa denk geliyor ezberlemeye gerek yok buraları
            {
               var computedHash = passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));      //computedhash hesaplanan hash
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] !=passwordHash[i])
                    {
                        return false;
                    }

                }
                        return true;
            }

        }
    }
}
