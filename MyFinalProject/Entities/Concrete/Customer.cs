using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
  public  class Customer:IEntity     //bu kısmı oluşturduk sen ıentitye bağlısın dedik customerla test yapıyoruz
    {
        public string CustomerId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
    }   
}
