using Infrastructure.Contracts;
using System; 

namespace Articles.WriteSide.Commands
{
	public interface IInsertCommentCommand : ICommand
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		string AddedByEmail { get; set; }
		string AddedByIp { get; set; }
		string Body { get; set; }
		Guid ArticleId { get; set; }
        Guid CategoryId { get; set; }
    }
}
