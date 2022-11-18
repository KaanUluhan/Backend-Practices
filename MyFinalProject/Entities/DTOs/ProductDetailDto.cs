using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class ProductDetailDto:IDto   //buraya ampul yeni üret 1. 3. sonra doldu gönder kısa yolu bu  uzun yolu her zaman yaptığım git interface ekle
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStocks { get; set; }
    }
}
