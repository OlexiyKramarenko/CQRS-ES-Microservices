using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Articles.ReadSide.Repository.Entities
{
	public class Category
	{
		[BsonId]
		//[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public DateTime AddedDate { get; set; }
		public string AddedBy { get; set; }
		public string Title { get; set; }
		public int Importance { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }

		[BsonElementAttribute(nameof(Category.Articles))]
		public List<Article> Articles { get; set; } = new List<Article>();
	}
}
