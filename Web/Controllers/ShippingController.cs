using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Server.Controllers
{
    [Route("api/v1/shipping")]
    public class ShippingController : Controller
    {
        [HttpGet]
        [Route("details/{id:guid}")]
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
        [Route("methods")]
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
    }
}