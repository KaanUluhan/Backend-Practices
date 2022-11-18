using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
  public interface IProductDal: IEntityRepository<Product>  // ıentitiyrepositoryi product için yapılandırdık oraya yazdık aşağıdaki kodlara gerek kalmadı
    {
        List<ProductDetailDto> GetProductDetails();   //dtonun detaylarını getirdik 

    }
}

//Code Refactoring : kodun iyileştirilmesi