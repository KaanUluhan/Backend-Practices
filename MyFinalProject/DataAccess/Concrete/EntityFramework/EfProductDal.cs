using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal  //sadece bu hareketi yaparak tüm veritabanı organizasyonlarını buradan yönetebilirim                                                    // IProductDal sen IproductDalsın ammupllerle aşağısı oluştu aşağıya ihtiyaç kalmadı yeni sistemle  entityframework çalışmasını yapıyoruz  nuget paket yönetten entityframwrokcore.sqlserver indirdim
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())    
            {
                var result = from p in context.Products
                             join c in context.Categories      //ürünlerle kategorileri join et demek
                             on p.CategoryId equals c.CategoryId   //eşitse
                             select new ProductDetailDto { ProductId = p.ProductId, ProductName = p.ProductName
                                 , CategoryName = c.CategoryName, UnitsInStocks = p.UnitsInStock };
          
            return result.ToList();

            }
        }
    }
}
