using Infrastructure.Contracts;

namespace Store.WriteSide.Commands
{
	public interface IDecrementProductUnitsInStockCommand : ICommand
	{
		int Quantity { get; set; }
	}
}
