using Infrastructure.Contracts; 

namespace Articles.WriteSide.Commands
{
	public interface IUpdateCommentCommand : ICommand
	{ 
		string Body { get; set; }
	}
}
