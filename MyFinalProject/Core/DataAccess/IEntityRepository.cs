using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{   //CORE BİZİM EVRENSEL KATMANIMIZ OLARAK DÜŞÜNDÜK HER YERE BAĞLI MAİN 
    //generic constraint generic kısıt demek herkes t yi kullanamasın diye kısıtlıyorum aşağıya where ile komutu yazıyorum tarif ediyorum 
    //class: referans tip olabilir demek
    //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new: new lenebilir olmalı
   public interface IEntityRepository<T> where T:class,IEntity,new()    //T öylesine verildi aşağıda da T yi burada yazdığım için yazdım
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  //ampul çıktı filtre vermemişse tüm datayı istiyo demektir businessdeki product manager ile alakalı
        T Get(Expression<Func<T, bool>> filter);  //filtre veriyosa filtreleyip veriyo demektir
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //List<T> GetAllByCategory(int categoryId); yukarıdaki filtreli muhabbeti yaptım diye bu koda ihtiyaç kalmadı
    }
}
