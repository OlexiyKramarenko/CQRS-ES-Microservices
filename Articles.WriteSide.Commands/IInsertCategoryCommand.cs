using Infrastructure.Contracts;
using System;

namespace Articles.WriteSide.Commands
{
	public interface IInsertCategoryCommand : ICommand
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; }
	}
}
