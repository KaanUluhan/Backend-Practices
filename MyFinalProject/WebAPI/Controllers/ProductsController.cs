using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]  // route bu isteği yaparken insanlar bize nası ulaşsın demek site linki gibi yorumladım netspor/api/products
    [ApiController]   //attrıbute denir 
    public class ProductsController : ControllerBase 
    {
        //Loose coupled  gevşek bağlılık
        //naming convention
        //Ioc Container -- Inversion of Control    listenin içine örneğin new product gibi referanslar atıp kim ihtiyaç duyuyorsa erişsin
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]                         //POSTMAN ile request gönderip sonuçları görebiliyoruz
        public IActionResult Getall()
        {
            //Dependency Chain   bağımlılık zinciri
            //Swagger

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
                return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)  //bana verdiğin ürünü oraya koy     
        {
            var result = _productService.Add(product);     //postman ile database e verimizi ekledik 
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest(result);
        }
    }
}
