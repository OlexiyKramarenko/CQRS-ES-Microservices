using Microsoft.AspNetCore.Mvc; 
using System;
using System.Collections.Generic;
using Web.Models.Store;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ManageStoreController : Controller
    { 
        #region Products
        [HttpGet]
        public IActionResult ManageProducts(int pageIndex, int pageSize)
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
        public IActionResult AddProduct(AddProductViewModel model)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult EditProduct(Guid id)
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

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(Guid id, AddProductViewModel model)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult DeleteProduct(Guid id)
        {
            return Ok();
        }
        #endregion

        #region ShippingMethod
        [HttpGet]
        public IActionResult ManageShippingMethods()
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
        public IActionResult DeleteShippingMethod(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddShippingMethod(AddShippingMethodViewModel model)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult EditShippingMethod(Guid id)
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

        [HttpPost("{id}")]
        public IActionResult UpdateShippingMethod(Guid id, EditShippingMethodViewModel model)
        {
            return Ok();
        }
        #endregion

        #region Department
        [HttpGet]
        public IActionResult ManageDepartments()
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
        public IActionResult DeleteDepartment(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult AddDepartment(AddDepartmentViewModel model)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult EditDepartment(Guid id)
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

        [HttpPost("{id}")]
        public IActionResult UpdateDepartment(Guid id, EditDepartmentViewModel model)
        {
            return Ok();
        }
        #endregion

        #region  Order
        [HttpGet]
        public IActionResult ManageOrders()
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
        public IActionResult DeleteOrder(Guid id)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult OrderDetails(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult UpdateOrderStatusId(Guid id, Guid statusId)
        {
            return Ok();
        }
        #endregion

        #region  OrderStatus
        [HttpGet]
        public IActionResult ManageOrderStatuses()
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
        public IActionResult DeleteOrderStatus(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult EditOrderStatus(Guid id)
        {
            var model = new EditOrderStatusViewModel
            {
                Id = Guid.NewGuid(),
                AddedBy = "aa",
                Title = "wwwww wwwww"
            };
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateOrderStatus(Guid id, EditOrderStatusViewModel model)
        {

            return Ok();
        }

        [HttpPut]
        public IActionResult AddOrderStatus(AddOrderStatusViewModel model)
        {
            return Ok();
        }
        #endregion
    }
}
