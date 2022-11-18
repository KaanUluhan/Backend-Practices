using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
  public interface IProductService
    {  //data olanların hepsini ıdataresult yaptım
        IDataResult<List<Product>> GetAll();
       IDataResult<List<Product>> GetAllByCategoryId(int id);  //e ticaretsisteminde sol tarafta kategoriyi seçtiğimde kategori ıdsine göre getiren otomasyon
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);           // buralar artık talep sistemi kurdum isteklerimi yazıyorum bu şekil
        IDataResult<List<ProductDetailDto>> GetProductDetails();              //  yeni işlem yapmıştık buraya da yazdım
        IDataResult<Product> GetById(int productId);      
        IResult Add(Product product);  //void di ıresult yaptım
        IResult Update(Product product);
      IResult AddTransactionalTest(Product product);  //uydurma bi method    hatalı bir para transferi olursa 


        //RESTFUL ----HTTP ----TCP
    }   
}
