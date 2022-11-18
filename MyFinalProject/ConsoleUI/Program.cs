using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    //SOLID !!!!
    // O HARFİ  OPEN CLOSED PRINCIPLE DEMEK 
    class Program
    {
        static void Main(string[] args)
        {
            //Data Transformation Object             
            //IoC 

            // CategoryTest();
            ProductTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),new CategoryManager(new EfCategoryDal()));   // !!!!!önemli parantez içinde new InMemoryProductDal yazıyodu onu değiştirdim çünkü entityframeworkün(Ef) çalışmasını istedim  parantez içindekiler çalışmasını istediğim şeyler

            var result = productManager.GetProductDetails();
            if (result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryName);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }

            foreach (var product in productManager.GetProductDetails().Data)    //productmanagerden sonra ne yazarsam oranın ürünleri gelir!!!!!!!!!!
            {
                Console.WriteLine(product.ProductName + "/" + product.CategoryName);
            }
        }
    }
}
