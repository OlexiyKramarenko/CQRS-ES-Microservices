using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Store;

namespace Web.Controllers
{
    [Route("api/v1/store")]
    public class StoreController : Controller
    { 
        #region Products
        [HttpGet]
        [Route("products/{id:guid}")]
        public IActionResult FindProduct(Guid id)
        {
            var model = new ShowProductViewModel
            {
                Id = Guid.NewGuid(),
                Title = "qqqq",
                Description = "rr r"
            };
            return Ok(model);
        }

        [HttpDelete]
        [Route("products/{id:guid}")]
        public IActionResult DeleteProduct(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        [Route("departments/{departmentId:guid}/products")]
        public IActionResult GetProducts(Guid departmentId)
        {
            var list = new List<ProductItemViewModel>
            {
               new ProductItemViewModel
               {
                    Id = Guid.NewGuid(),
                    Title= "title",
                    AverageRating = 45,
                    DiscountPercentage = 4,
                    UnitPrice = 4,
                    Votes = 7,
                    UnitsInStock = 4
               }
            };
            return Ok(list);
        }

        [HttpGet]
        [Route("departments")]
        public IActionResult GetDepartments()
        {
            var list = new List<DepartmentItemViewModel>
            {
                new DepartmentItemViewModel
                {
                     Id = Guid.NewGuid(),
                     Title = "ttttttt ttt",
                     Description = "qqqqq"
                },
                new DepartmentItemViewModel
                {
                     Id = Guid.NewGuid(),
                     Title = "ssss sssss ss",
                     Description = "rrrrr"
                },
            };
            return Ok(list);
        }
        #endregion

        #region Shipping

        [HttpGet]
        [Route("shipping-details/{id:guid}")]
        public IActionResult FindShippingDetails(Guid id)
        {
            var model = new ShippingDetailsViewModel
            {
                Title = "EEEEEE",
                Price = 7
            };
            return Ok(model);
        }

        [HttpGet]
        [Route("shipping-methods")]
        public IActionResult GetShippingMethods()
        {
            var list = new List<ShippingMethodItemViewModel>
            {
                 new ShippingMethodItemViewModel
                 {
                      Id = Guid.NewGuid(),
                      Text = "dddddddddd"
                 }
            };
            return Ok(list);
        }

        [HttpGet]
        [Route("checkout")]
        public IActionResult Checkout()
        {
            return Ok();
        }

        [HttpPost]
        [Route("checkout")]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            return Ok();
        }
        #endregion

        #region ShoppingCart

        [HttpGet]
        [Route("shopping-cart")]
        public IActionResult GetShoppingCart()
        {
            return Ok();
        }
        
        [HttpPost]
        [Route("shopping-cart")]
        public IActionResult InsertIntoShoppingCart(ShoppingCartItemViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("shopping-cart/{itemId:guid}")]
        public IActionResult DeleteFromShoppingCart(Guid itemId)
        {
            return Ok();
        }
        #endregion

        #region Order

        [HttpGet]
        [Route("order-summary")]
        public IActionResult GetOrderSummary()
        {
            return Ok();
        }

        [HttpPost]
        [Route("order-summary")]
        public IActionResult OrderSummary(OrderSummaryViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("order-completed")]
        public IActionResult OrderCompleted()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult OrderHistory(Guid statusId, DateTime fromDate, DateTime toDate)
        {
            return Ok();
        }
        #endregion
    }
}
