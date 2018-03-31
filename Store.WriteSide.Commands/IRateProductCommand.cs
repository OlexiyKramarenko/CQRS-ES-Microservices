using Infrastructure.Contracts;

namespace Store.WriteSide.Commands
{
	public interface IRateProductCommand : ICommand
	{
		int Rating { get; set; }
	}
}
