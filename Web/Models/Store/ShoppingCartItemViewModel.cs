using System;

namespace Web.Models.Store
{
	public class ShoppingCartItemViewModel
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public decimal UnitPrice { get; set; }

		private int _quantity;
		public int Quantity
		{
			get
			{
				if (_quantity <= 0)
					_quantity = 1;

				return _quantity;
			}
			set { _quantity = value; }
		}
	}
}
