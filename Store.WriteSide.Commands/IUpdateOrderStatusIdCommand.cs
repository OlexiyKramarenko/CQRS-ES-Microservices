using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Commands
{
	public interface IUpdateOrderStatusIdCommand : ICommand
	{
		Guid StatusId { get; set; }
	}
}
