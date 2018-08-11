using Articles.ReadSide.Repository.Entities;
using Articles.ReadSide.WCF.Service.DTO;
using AutoMapper;

namespace Articles.ReadSide.WCF.Service.MappingProfiles
{
    public class ArticlesProfile : Profile
    {
        public ArticlesProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Comment, CommentDto>();
        }
    }
}