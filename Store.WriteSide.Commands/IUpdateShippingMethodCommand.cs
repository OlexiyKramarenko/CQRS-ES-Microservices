using Infrastructure.Contracts;

namespace Store.WriteSide.Commands
{
	public interface IUpdateShippingMethodCommand : ICommand
	{
		string Title { get; set; }
		decimal Price { get; set; }
	}
}
