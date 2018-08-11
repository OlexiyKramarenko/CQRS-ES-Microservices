using System;
using System.Runtime.Serialization;

namespace Articles.ReadSide.WCF.Service.DTO
{
    [DataContract]
    public class CommentDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public DateTime AddedDate { get; set; }
        [DataMember]
        public string AddedBy { get; set; }
        [DataMember]
        public string AddedByEmail { get; set; }
        [DataMember]
        public string AddedByIp { get; set; }
        [DataMember]
        public string Body { get; set; }
        [DataMember]
        public string ArticleId { get; set; }
    }
}