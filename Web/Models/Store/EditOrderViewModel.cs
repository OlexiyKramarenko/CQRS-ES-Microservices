using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Models.Store
{
    public class EditOrderViewModel
    {
        public Guid Id { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime AddedDate { get; set; }
        public string AddedBy { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerFax { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingMethod { get; set; }
        public int SubTotal { get; set; }
        public string Shipping { get; set; }
        public string StatusTitle { get; set; }
        public Guid StatusId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
		public DateTime ShippedDate { get; set; }
        public string TrackingId { get; set; }
        public string TransactionId { get; set; }
        public List<OrderItemViewModel> Items { get; set; }
        public SelectList OrderStatuses { get; set; }
    }
}
