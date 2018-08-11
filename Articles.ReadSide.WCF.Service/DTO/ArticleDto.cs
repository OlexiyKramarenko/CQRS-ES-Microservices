using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Articles.ReadSide.WCF.Service.DTO
{
    [DataContract]
    public class ArticleDto
    {
        [DataMember]
        public String Id { get; set; }
        [DataMember]
        public DateTime AddedDate { get; set; }
        [DataMember]
        public string AddedBy { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Abstract { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public DateTime ReleaseDate { get; set; }
        [DataMember]
        public DateTime ExpireDate { get; set; }
        [DataMember]
        public bool Approved { get; set; }
        [DataMember]
        public bool Listed { get; set; }
        [DataMember]
        public bool CommentsEnabled { get; set; }
        [DataMember]
        public bool OnlyForMembers { get; set; }
        [DataMember]
        public int ViewCount { get; set; }
        [DataMember]
        public int Votes { get; set; }
        [DataMember]
        public int TotalRating { get; set; }
        [DataMember]
        public string CategoryId { get; set; }
        [DataMember]
        public List<CommentDto> Comments { get; set; } = new List<CommentDto>();
    }
}