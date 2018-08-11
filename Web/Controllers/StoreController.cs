using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.Models.Store;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StoreController : Controller
    { 
        #region Products
        [HttpGet]
        public IActionResult ShowProduct(Guid id)
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
        public IActionResult DeleteProduct(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult BrowseProducts(Guid departmentId)
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
        public IActionResult ShowDepartments()
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
        public IActionResult ShippingDetails(Guid id)
        {
            var model = new ShippingDetailsViewModel
            {
                Title = "EEEEEE",
                Price = 7
            };
            return Ok(model);
        }

        [HttpGet]
        public IActionResult ShippingMethods()
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
        public IActionResult Checkout()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel model)
        {
            return Ok();
        }
        #endregion

        #region ShoppingCart

        [HttpGet]
        public IActionResult ShoppingCart()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult ShoppingCart(IFormCollection form)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddToShoppingCart(ShoppingCartItemViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult RemoveFromShoppingCart(Guid id)
        {
            return Ok();
        }
        #endregion

        #region Order

        [HttpGet]
        public IActionResult OrderSummary()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult OrderSummary(OrderSummaryViewModel model)
        {
            return Ok();
        }

        [HttpGet]
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
