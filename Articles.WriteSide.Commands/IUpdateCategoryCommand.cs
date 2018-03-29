using Infrastructure.Contracts; 

namespace Articles.WriteSide.Commands
{
	public interface IUpdateCategoryCommand : ICommand
	{ 
		string Title { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; }
	}
}
