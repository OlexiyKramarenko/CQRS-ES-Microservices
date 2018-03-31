using Infrastructure.Contracts;
using System;

namespace Store.WriteSide.Commands
{
	public interface IUpdateDepartmentCommand : ICommand
	{
		 DateTime AddedDate { get; set; }
		 string Title { get; set; }
		 int Importance { get; set; }
		 string Description { get; set; }
		 string ImageUrl { get; set; } 
	}
}
