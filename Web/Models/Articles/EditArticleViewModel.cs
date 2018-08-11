using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.Articles
{
	public class EditArticleViewModel
	{
        ////[JsonProperty("id")]
        public Guid? Id { get; set; }

        ////[JsonProperty("addedDate")]
        //////[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        ////public DateTime AddedDate { get; set; }

        ////    [JsonProperty("addedBy")]
        //public string AddedBy { get; set; }

        ////   [JsonProperty("viewCount")]
        //public int ViewCount { get; set; }

        ////  [JsonProperty("votes")]
        //public int Votes { get; set; }

        //// [JsonProperty("averageRating")]
        //public int AverageRating { get; set; }

        ////  [JsonProperty("category")]
        //public string Category { get; set; }

        //// [JsonProperty("categoryId")]
        //public Guid CategoryId { get; set; }

        ////  [JsonProperty("title")]
        //public string Title { get; set; }

        ////  [JsonProperty("abstract")]
        //public string Abstract { get; set; }

        ////[JsonProperty("body")]
      public string Body { get; set; }

        //// [JsonProperty("country")]
        //public string Country { get; set; }

        ////  [JsonProperty("state")]
        //public string State { get; set; }

        //// [JsonProperty("city")]
        //public string City { get; set; }

        ////[JsonProperty("releaseDate")]
        //////[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        ////public DateTime ReleaseDate { get; set; }

        ////[JsonProperty("expireDate")]
        //////[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        ////public DateTime ExpireDate { get; set; }

        //// [JsonProperty("approved")]
        //public bool Approved { get; set; }

        ////  [JsonProperty("listed")]
        //public bool Listed { get; set; }

        ////   [JsonProperty("commentsEnabled")]
        //public bool CommentsEnabled { get; set; }

        ////   [JsonProperty("onlyForMembers")]
        //public bool OnlyForMembers { get; set; }
    }
}
