using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Articles.ReadSide.WCF.Service.DTO
{
    [DataContract]
    public class CategoryDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public DateTime AddedDate { get; set; }
        [DataMember]
        public string AddedBy { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public int Importance { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public List<ArticleDto> Articles { get; set; } = new List<ArticleDto>();
    }
}