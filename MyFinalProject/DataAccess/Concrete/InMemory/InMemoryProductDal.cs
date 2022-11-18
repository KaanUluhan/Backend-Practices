using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal  //önce ampulle yukarıdaki kütüphaneyi ekledik sonra yine ampulle interface yapıp aşağıyı elde ettik
    {
        List<Product> _products;  // alt çizgiyle verilirmiş genelde
        public InMemoryProductDal()  //ctor ile
        {
            // Orcale ,Sql server, Postgres, MongoDb
            _products = new List<Product> {
          new Product { ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15 },
          new Product { ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3 },
          new Product { ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2 },
          new Product { ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65 },
          new Product { ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1 }};
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //LINQ Language Integrated Query
            //Product productToDelete = null ; 
            //foreach (var p in _products)  //foreach tek tek gezmek demek 
            //{
            //    if (product.ProductId == p.ProductId)
            //    {
            //        productToDelete = p;
            //    }                               bu kısım mantığını anlatmak için aşağıda ki daha kısa                  

            //}
          Product productToDelete = _products.SingleOrDefault(p=>p.ProductId == product.ProductId); // single or default kısmı foreach yap demek     p=> lambda 
           
            _products.Remove(productToDelete);
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return _products;  //veritabanını olduğu gibi döndür
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
           return _products.Where(p=>p.CategoryId == categoryId).ToList();   // where içindeki şarta uyan bütün elemanları yeni bir liste haline getirir ve onu döndürür
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            //Gönderdiğim ürün ıdsine sahip olan listedeki ürünü bul 
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); // single or default kısmı foreach yap demek
            productToUpdate.ProductName = product.ProductName;   // updateden gönderdiğim ismi producttaki isim yapabiliriz alttakilerde o şekil
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
 