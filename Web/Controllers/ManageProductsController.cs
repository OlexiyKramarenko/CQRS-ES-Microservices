using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Server.Controllers
{
    [Route("api/v1/admin/products")]
    public class ManageProductsController : Controller
    {
        [HttpGet]
        public IActionResult GetProducts(int pageIndex, int pageSize)
        {
            var response = new List<ProductItemViewModel>
            {
                new ProductItemViewModel{
                    AverageRating = 1,
                    DiscountPercentage =2,
                    FinalUnitPrice = 5,
                    Id = Guid.NewGuid(),
                    Title = "qqqq qqqq",
                    UnitPrice = 55,
                    UnitsInStock = 5
                },
                new ProductItemViewModel{
                    AverageRating = 1,
                    DiscountPercentage =2,
                    FinalUnitPrice = 5,
                    Id = Guid.NewGuid(),
                    Title = "aaaaa aaaaaa aaaaaa",
                    UnitPrice = 55,
                    UnitsInStock = 5
                },
            };
            return Ok(response);
        }

        

        [HttpGet]
        [Route("{productId:guid}")]
        public IActionResult GetProduct(Guid productId)
        {
            var response = new EditProductViewModel
            {
                Description = "aaaa",
                DiscountPercentage = 5,
                Id = Guid.NewGuid(),
                SKU = "ss",
                Title = "qqq",
                UnitPrice = 4,
                UnitsInStock = 7
            };
            return Ok(response);
        }

        //TODO: Will be implemented later:
        /* 
        [HttpPost]
        public IActionResult InsertProduct(AddProductViewModel model)
        {
            return Ok();
        }

        [HttpPut]
        [Route("{productId:guid}")]
        public IActionResult UpdateProduct(Guid productId, AddProductViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{productId:guid}")]
        public IActionResult DeleteProduct(Guid productId)
        {
            return Ok();
        }
        */
    }
}
