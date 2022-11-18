using Business.Abstract;
using Business.BusinessAspcets.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.Concrete
{
    //interfaceler referans tutuculardır
    //burası bizim ürün eklediğimiz kısım
    // bir entity menager ıproductdal hariç başka birini enjekte edemez ıcategorydal gibi
    public class ProductManager : IProductService  //klasik ampulleri devam ettir
    {
        IProductDal _productDal;   //soyut nesneyle bağlantı kurucaz
        ICategoryService _categoryService;  //soyut nesneyle bağlantı kurucaz

      
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //LOGLAMA = KİM NEZAMAN NEREDE NE ÜRÜN EKLEDİ BUNLARI ANLARIZ  ILOGGER FALAN YAZDIKLARIMIZA DİKKAT ET
        [SecuredOperation("product.add,admin")]            //bu tür keylerde küçük harf yazılırs
        [ValidationAspect(typeof(ProductValidator))]      //burası autofacin içindeki classla bağlantılı
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)   //void di ıresult yaptık  //add methodu senin bir validation aspectin var autofac de devreye sokuyor
        {
            //bir kategoride en fazla 10 ürün olabilir örneği    private CheckIfProductCountOfCategoryCorrect aşağıda  burada ve businnesrule.cs de 
            //Aynı isimde ürün eklenemez örneği    private   CheckIfProductNameExists  aşağıda burada ve businnesrule.cs de
            //Eğer mevcut kategori sayısı 15 i geçtiyse sisteme yeni ürün eklenemez örneği 
            //business code
            //validation 
            // iş kuralları ayrı doğrulama ayrı yazılır

            IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceded()) ; //core daki business rules da işlemleri yaptık burada toplu şekilde işleme soktuk yeni kural mı talep edildi virgül koyup buraya ekleriz

            if (result != null)

            {
                return result;
           
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);         
     
        }   

       [CacheAspect]//key,value
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            //iş kodları
            // Yetkisi Var mı ?
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);  // dataresult döndürüyorum çalıştığım tip budur , buda döndürdüğüm datadır,işlem sonucumdur, seni bilgilendirecek yapımdır...


        }
        //[SecuredOperation("product.add,admins")]
        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
          return new SuccessDataResult<List<Product>> (_productDal.GetAll(p=>p.CategoryId==id));           // filtreleme yaptık ne istediğimizi belirttik   ÖNEMLİ:ıproductserviceden istedğimizi çektik 
        }
        [CacheAspect]
        //[PerformanceAspect(5)]   githubda var
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId ==productId));   //Successdataresult içinde product var onu da constructor la parantez içi işlemini yaptırıyoruz 
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice>=min && p.UnitPrice<=max));  // filtreleme yaptık ne istediğimizi belirttik   ÖNEMLİ:ıproductserviceden istedğimizi çektik 
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        { 
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }

       
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)  //sadece burayı etkileyeceği için private
        {
            //Select count(*) from products where CategoryId=1 ile aynı 
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;  //10 ürün örneği sonra messagesa gidip bişiler yazdım
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)  //sadece burayı etkileyeceği için private
        {
            //Select count(*) from products where CategoryId=1 ile aynı 
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();  //any şuna uyan kayıt  var mı //Aynı isimde ürün eklenemez örneği  messega kısmına ekleme yapıldı
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);      // categorservice deki isteklerle ilgili örnek yukarı productdal ın altına categoryservice eklemiştik onunla ilgili message kısmına da ekleme yapıldı 47. satıra virgülden sonra eklemeyi de yaptık
            }
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Product product)     //buraların içi githubda var 
        {
            throw new NotImplementedException();
        }
    }
}
