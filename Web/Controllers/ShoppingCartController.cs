using Microsoft.AspNetCore.Mvc;
using System;
using Web.Models.Store;

namespace Server.Controllers
{
    [Route("api/v1/shopping-cart")]
    public class ShoppingCartController : Controller
    {
        [HttpGet]
        public IActionResult GetShoppingCart()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertIntoShoppingCart(ShoppingCartItemViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("{itemId:guid}")]
        public IActionResult DeleteFromShoppingCart(Guid itemId)
        {
            return Ok();
        }
    }
}