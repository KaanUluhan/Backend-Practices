using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
public static class Messages  //tek bişi olacağı zaman static galiba     publicde pascalkeys     kuralı olur büyük harf
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid= "ürün ismi geçersiz";
        internal static string MaintenanceTime= "sistem bakımda";
        internal static string ProductsListed= "ürünler listelendi";
        internal static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 ürün olabilir";
        internal static string ProductNameAlreadyExists="Bu isimde zaten başka bir ürün var";
        internal static string CategoryLimitExceded="Kategori limiti aşıldığı için yeni ürün eklenemiyor";
        internal static string AuthorizationDenied="Yetkiniz yok.";
    }
}
