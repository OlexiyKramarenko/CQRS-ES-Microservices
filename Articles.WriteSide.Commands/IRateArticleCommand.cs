using Infrastructure.Contracts; 

namespace Articles.WriteSide.Commands
{
	public interface IRateArticleCommand : ICommand
	{ 
		int Rating { get; set; }
	}
}
