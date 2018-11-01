using Microsoft.AspNetCore.Mvc;
using Web.Models.Store;

namespace Web.Controllers
{
    [Route("api/v1/checkout")]
    public class CheckoutController : Controller
    { 
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
    }
}
