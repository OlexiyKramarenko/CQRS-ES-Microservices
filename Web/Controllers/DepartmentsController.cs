using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Server.Controllers
{
    [Route("api/v1/departments")]
    public class DepartmentsController : Controller
    {
        [HttpGet]        
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

        [HttpGet]
        [Route("{departmentId:guid}/products")]
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
    }
}