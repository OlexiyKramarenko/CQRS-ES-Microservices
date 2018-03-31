using System; 

namespace Store.WriteSide.Commands
{
	public interface IInsertDepartmentCommand
	{
		Guid Id { get; set; }
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string Title { get; set; }
		int Importance { get; set; }
		string Description { get; set; }
		string ImageUrl { get; set; }
	}
}
