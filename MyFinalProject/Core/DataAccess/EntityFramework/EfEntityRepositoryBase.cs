using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;



namespace Core.DataAccess.EntityFramework
{
    //BURAYA YAZACAĞMIZ KODU TÜM HER YERDE KULLANABİLİRİZ CORE MAİN
    public class EfEntityRepositoryBase<TEntity,Tcontext>:  IEntityRepository<TEntity>     
        where TEntity: class,IEntity, new()    where Tcontext : DbContext,new()    //SADECE BURALAR ERİŞİM OLSUN DİYE yazdım diğer yere where muhabbetini
    {
        public void Add(TEntity entity)
        {
            using (Tcontext context = new Tcontext())  //using tabtab
            {
                var addedEntity = context.Entry(entity); // ben şimdi veri kaynağımla ilişkilendirdim bunu
                addedEntity.State = EntityState.Added;  // işlemi yaptık
                context.SaveChanges();                  //işlemi gerçekleştir            
            }
        }
        public void Delete(TEntity entity)
        {
            using (Tcontext context = new Tcontext())  //using tabtab
            {
                var deletedEntity = context.Entry(entity); // ben şimdi veri kaynağımla ilişkilendirdim bunu
                deletedEntity.State = EntityState.Deleted;  // işlemi yaptık
                context.SaveChanges();                  //işlemi gerçekleştir            
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (Tcontext context = new Tcontext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);       //productın içi değişir sadece customer sa o yazılır falan singleordefault foreach muhabbetiydi 

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (Tcontext context = new Tcontext())
            {
                return filter == null ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();  //filter null mı evetse tümünü getir değilse  devamı 
            }
        }

        public void Update(TEntity entity)
        {
            using (Tcontext context = new Tcontext())  //using tabtab
            {
                var updatedEntity = context.Entry(entity); // ben şimdi veri kaynağımla ilişkilendirdim bunu
                updatedEntity.State = EntityState.Modified;  // işlemi yaptık
                context.SaveChanges();                  //işlemi gerçekleştir            
            }
        }
    }
}
