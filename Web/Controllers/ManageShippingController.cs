using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Web.Controllers
{
    [Route("api/v1/admin/shipping-methods")]
    public class ManageShippingController : Controller
    {
        [HttpGet]
        public IActionResult GetShippingMethods()
        {
            var response = new List<ManageShippingMethodItemViewModel>
            {
                 new ManageShippingMethodItemViewModel
                 {
                      Id = Guid.NewGuid(),
                      Price = 5,
                      Title = "qqqqq qqqqqq"
                 },
                 new ManageShippingMethodItemViewModel
                 {
                      Id = Guid.NewGuid(),
                      Price = 5,
                      Title = "aaaa aaa aaaaa"
                 },
            };
            return Ok(response);
        }

        [HttpGet]
        [Route("{methodId:guid}")]
        public IActionResult FindShippingMethod(Guid methodId)
        {
            var response = new EditShippingMethodViewModel
            {
                Id = Guid.NewGuid(),
                AddedBy = "aaaa",
                Title = "wwwwww wwwww",
                Price = 5
            };
            return Ok(response);
        }
         
        //TODO: Will be implemented later:
        /*
        [HttpGet]
        [Route("{methodId:guid}")]
        public IActionResult DeleteShippingMethod(Guid methodId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult InsertShippingMethod(AddShippingMethodViewModel model)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{methodId:guid}")]
        public IActionResult UpdateShippingMethod(Guid methodId, EditShippingMethodViewModel model)
        {
            return Ok();
        }
        */
    }
}
