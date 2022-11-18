using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın
   public class Category:IEntity //ampul çıkmıştı ıentity yazınca basınca ekliyo yukarı kütühaneye
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
