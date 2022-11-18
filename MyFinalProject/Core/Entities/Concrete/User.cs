using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete          //northwind de 3 tane tablo oluşturduk onları burada tanımladık dosyalara ayırdık  3 tane ayrı ayrı oldu moveladık üstüne basılı tut move yap hepsini buraya yazmıştık normalde
{                                             
    public class User:IEntity                        
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
    }
}
