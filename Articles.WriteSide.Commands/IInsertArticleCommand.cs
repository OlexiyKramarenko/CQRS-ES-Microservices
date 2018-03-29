using Infrastructure.Contracts;
using System;

namespace Articles.WriteSide.Commands
{
	public interface IInsertArticleCommand : ICommand
	{ 
		DateTime AddedDate { get; set; }
		string AddedBy { get; set; }
		Guid CategoryId { get; set; }
		string Title { get; set; }
		string Abstract { get; set; }
		string Body { get; set; }
		string Country { get; set; }
		string State { get; set; }
		string City { get; set; }
		DateTime ReleaseDate { get; set; }
		DateTime ExpireDate { get; set; }
		bool Approved { get; set; }
		bool Listed { get; set; }
		bool CommentsEnabled { get; set; }
		bool OnlyForMembers { get; set; }
		int ViewCount { get; set; }
		int Votes { get; set; }
		int TotalRating { get; set; }		
	}	
}
