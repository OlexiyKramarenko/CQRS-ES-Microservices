using System;
using Infrastructure.Contracts;

namespace Articles.WriteSide.Commands.Cancel
{
	public class InsertCommentCancelCommand : IInsertCommentCancelCommand
	{
		public Guid Id { get; }
	}
}
