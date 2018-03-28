using System;

namespace Infrastructure.Contracts
{
	public interface ICommand
	{
		Guid Id { get; }
	}
}
