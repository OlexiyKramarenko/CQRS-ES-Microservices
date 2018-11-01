using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Web.Controllers
{
    [Route("api/v1/admin")]
    public class ManageStoreController : Controller
    {
        #region Products
        [HttpGet]
        [Route("products")]
        public IActionResult GetProducts(int pageIndex, int pageSize)
        {
            var list = new List<ProductItemViewModel>
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
            return Ok();
        }

        [HttpPost]
        [Route("products")]
        public IActionResult InsertProduct(AddProductViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("products/{productId:guid}")]
        public IActionResult GetProduct(Guid productId)
        {
            var model = new EditProductViewModel
            {
                Description = "aaaa",
                DiscountPercentage = 5,
                Id = Guid.NewGuid(),
                SKU = "ss",
                Title = "qqq",
                UnitPrice = 4,
                UnitsInStock = 7
            };
            return Ok(model);
        }

        [HttpPut]
        [Route("products/{productId:guid}")]
        public IActionResult UpdateProduct(Guid productId, AddProductViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("products/{productId:guid}")]
        public IActionResult DeleteProduct(Guid productId)
        {
            return Ok();
        }

        #endregion

        #region ShippingMethod
        [HttpGet]
        [Route("shipping-methods")]
        public IActionResult GetShippingMethods()
        {
            var list = new List<ManageShippingMethodItemViewModel>
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
            return Ok(list);
        }

        [HttpGet]
        [Route("shipping-methods/{methodId:guid}")]
        public IActionResult DeleteShippingMethod(Guid methodId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("shipping-methods")]
        public IActionResult InsertShippingMethod(AddShippingMethodViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("shipping-methods/{methodId:guid}")]
        public IActionResult FindShippingMethod(Guid methodId)
        {
            var model = new EditShippingMethodViewModel
            {
                Id = Guid.NewGuid(),
                AddedBy = "aaaa",
                Title = "wwwwww wwwww",
                Price = 5
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("shipping-methods/{methodId:guid}")]
        public IActionResult UpdateShippingMethod(Guid methodId, EditShippingMethodViewModel model)
        {
            return Ok();
        }
        #endregion

        #region Department
        [HttpGet]
        [Route("departments")]
        public IActionResult GetDepartments()
        {
            var list = new List<DepartmentItemViewModel>
            {
                new DepartmentItemViewModel
                {
                     Id = Guid.NewGuid(),
                     Title = "aaaa aaaaa",
                     Description = "rrrrrrrrrrrr rrrrr",
                }
            };
            return Ok(list);
        }

        [HttpGet]
        [Route("departments/{departmentId:guid}")]
        public IActionResult DeleteDepartment(Guid departmentId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("departments")]
        public IActionResult InsertDepartment(AddDepartmentViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        [Route("departments/{departmentId:guid}")]
        public IActionResult GetDepartment(Guid departmentId)
        {
            var model = new EditDepartmentViewModel
            {
                Id = Guid.NewGuid(),
                AddedBy = "aaa",
                Description = "asssssddddddd ddd",
                Importance = 4,
                Title = "rrrr"
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("departments/{departmentId:guid}")]
        public IActionResult UpdateDepartment(Guid departmentId, EditDepartmentViewModel model)
        {
            return Ok();
        }
        #endregion

        #region  Order
        [HttpGet]
        [Route("orders")]
        public IActionResult GetOrders()
        {
            var list = new List<ManageOrderItemViewModel>
            {
                new ManageOrderItemViewModel
                {
                     Id = Guid.NewGuid(),
                     Shipping = "AHA",
                     ShippingLastName = "Alala",
                     Subtotal = 4
                }
            };
            return Ok(list);
        }

        [HttpGet]
        [Route("orders/{orderId:guid}")]
        public IActionResult DeleteOrder(Guid orderId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("orders/{orderId:guid}")]
        public IActionResult OrderDetails(Guid orderId)
        {
            return Ok();
        }

        [HttpPost]
        //[HttpPut]
        [Route("orders/{orderId:guid}")]
        public IActionResult UpdateOrderStatusId(Guid orderId, [FromBody]Guid statusId)
        {
            return Ok();
        }
        #endregion

        #region  OrderStatus
        [HttpGet]
        [Route("statuses")]
        public IActionResult GetOrderStatuses()
        {
            var list = new List<ManageOrderItemViewModel>
            {
                new ManageOrderItemViewModel
                {
                     Id= Guid.NewGuid(),
                     Subtotal = 5,
                     ShippingLastName = "AAAA",
                     Shipping = "qqqqq"
                }
            };
            return Ok(list);
        }

        [HttpGet]
        [Route("statuses/{statusId:guid}")]
        public IActionResult DeleteOrderStatus(Guid statusId)
        {
            return Ok();
        }

        [HttpGet]
        [Route("statuses/{statusId:guid}")]
        public IActionResult FindOrderStatus(Guid statusId)
        {
            var model = new EditOrderStatusViewModel
            {
                Id = Guid.NewGuid(),
                AddedBy = "aa",
                Title = "wwwww wwwww"
            };
            return Ok(model);
        }

        [HttpPut]
        [Route("statuses/{statusId:guid}")]
        public IActionResult UpdateOrderStatus(Guid statusId, EditOrderStatusViewModel model)
        {
            return Ok();
        }

        [HttpPut]
        [Route("statuses")]
        public IActionResult InsertOrderStatus(AddOrderStatusViewModel model)
        {
            return Ok();
        }
        #endregion
    }
}
