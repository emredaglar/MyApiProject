﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApiProject.BusinessLayer.Abstract;
using MyApiProject.DtoLayer.ProductDtos;
using MyApiProject.EntityLayer.Concrete;

namespace MyApiProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public ActionResult ProductList()
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            Product product = new Product();
            product.ProductStock = createProductDto.ProductStock;
            product.ProductPrice = createProductDto.ProductPrice;
            product.ProductName = createProductDto.ProductName;
            product.CategoryId = createProductDto.CategoryId;
            _productService.TInsert(product);
            return Ok("Ekleme Başarılı");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Silme Başarılı");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {

            Product product = new Product();
            product.ProductStock = updateProductDto.ProductStock;
            product.ProductPrice = updateProductDto.ProductPrice;
            product.ProductName = updateProductDto.ProductName;
            product.CategoryId = updateProductDto.CategoryId;
            _productService.TUpdate(product);
            return Ok("Güncelleme Başarılı");

        }

    }
}
