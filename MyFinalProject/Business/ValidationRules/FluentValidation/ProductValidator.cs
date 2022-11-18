using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()   //ctor tabtab    kurallar buraya   hangi nesne için validatör yazıcaksam buranın içine yazıyorum
        {
            RuleFor(p => p.ProductName).NotEmpty();         //boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2);   //product namein minlengthi 2 karakter olmalıdır
            RuleFor(p => p.UnitPrice).NotEmpty();           //boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0);       // unitprice 0 dan büyük olacak
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);   //kategori idsi 1 olduğunda unitprice 10a eşit veya büyük olacak
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalı");     //ürün ismi A ile başlamalı   startwithA da ampul çıkar aşağıda oluşturur ,mesajla gösterir
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");     //false döndürünce patlamasın diye argı döndürdük
        }
    }
}
