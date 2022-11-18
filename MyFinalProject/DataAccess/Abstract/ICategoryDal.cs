using System;
using Entities.Concrete;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;

namespace DataAccess.Abstract
{
   public interface ICategoryDal:IEntityRepository<Category> //ıentitiyrepositoryi Categori için yapılandırdık oraya yazdık aşağıdaki kodlara gerek kalmadı
    {
        //List<Category> GetAll(); //ampul çıktı add reference to entities seçtim     aşağıya her eklediğimde yeni bişi ınmemory sayfasında ampul çıkar eksik bilgi var demek implement edip devam 
        //void Add(Category Category);
        //void Update(Category Category);
        //void Delete(Category Category);
        //List<Category> GetAllByCategory(int categoryId);

    }
}
