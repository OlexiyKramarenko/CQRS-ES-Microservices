using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Commands
{
	public interface IInsertOrderStatusCommand : ICommand
	{
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
	}
}
