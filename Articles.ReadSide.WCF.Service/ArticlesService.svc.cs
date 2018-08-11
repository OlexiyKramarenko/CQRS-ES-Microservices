using Articles.ReadSide.Repository;
using Articles.ReadSide.Repository.Entities;
using Articles.ReadSide.WCF.Service.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace Articles.ReadSide.WCF.Service
{
    public class ArticlesService : IArticlesService
    {
        private IMapper _mapper;
        private IArticlesRepository _articlesRepository;

        public ArticlesService()
        {

        }

        public ArticlesService(IArticlesRepository articlesRepository, IMapper mapper)
        {
            _articlesRepository = articlesRepository;
            _mapper = mapper;
        }

        public string GetArticleBody(string categoryId, string articleId)
        {
            return _articlesRepository.GetArticleBody(categoryId, articleId);
        }

        public ArticleDto GetArticleById(Guid articleId)
        {
            Article article = _articlesRepository.GetArticleById(articleId);
            ArticleDto dto = _mapper.Map<ArticleDto>(article);
            return dto;
        }

        public int GetArticleCount()
        {
            return _articlesRepository.GetArticleCount();
        }

        public int GetArticleCountByCategoryId(Guid categoryId)
        {
            return _articlesRepository.GetArticleCount(categoryId);
        }

        public IList<ArticleDto> GetArticles(int pageIndex, int pageSize)
        {
            IList<Article> articles = _articlesRepository.GetArticles(pageIndex, pageSize);
            List<ArticleDto> dto = _mapper.Map<List<ArticleDto>>(articles);
            return dto;
        }

        public IList<ArticleDto> GetArticlesByCategoryId(Guid categoryId, int pageIndex, int pageSize)
        {
            IList<Article> articles = _articlesRepository.GetArticles(categoryId, pageIndex, pageSize);
            IList<ArticleDto> dto = _mapper.Map<IList<ArticleDto>>(articles);
            return dto;
        }

        public IList<CategoryDto> GetCategories()
        {
            IList<Category> categories = _articlesRepository.GetCategories();
            IList<CategoryDto> dto = _mapper.Map<IList<CategoryDto>>(categories);
            return dto;
        }

        public IList<CategoryDto> GetCategoriesByIndex(int pageSize, int pageIndex)
        {
            IList<Category> categories = _articlesRepository.GetCategories(pageSize, pageIndex);
            IList<CategoryDto> dto = _mapper.Map<IList<CategoryDto>>(categories);
            return dto;
        }

        public CategoryDto GetCategoryById(Guid categoryId)
        {
            Category category = _articlesRepository.GetCategoryById(categoryId);
            CategoryDto dto = _mapper.Map<CategoryDto>(category);
            return dto;
        }

        public CommentDto GetCommentById(Guid commentId)
        {
            Comment comment = _articlesRepository.GetCommentById(commentId);
            CommentDto dto = _mapper.Map<CommentDto>(comment);
            return dto;
        }

        public int GetCommentCountByArticleId(Guid articleId)
        {
            return _articlesRepository.GetCommentCount(articleId);
        }

        public int GetCommentCount()
        {
            return _articlesRepository.GetCommentCount();
        }

        public IList<CommentDto> GetComments(int pageIndex, int pageSize)
        {
            IList<Comment> comments = _articlesRepository.GetComments(pageIndex, pageSize);
            List<CommentDto> dto = _mapper.Map<List<CommentDto>>(comments);
            return dto;
        }

        public IList<CommentDto> GetCommentsByArticleId(Guid articleId, int pageIndex, int pageSize)
        {
            IList<Comment> comments = _articlesRepository.GetComments(articleId, pageIndex, pageSize);
            IList<CommentDto> dto = _mapper.Map<IList<CommentDto>>(comments);
            return dto;
        }

        public int GetPublishedArticleCount(DateTime currentDate)
        {
            return _articlesRepository.GetPublishedArticleCount(currentDate);
        }

        public int GetPublishedArticleCountByCategoryId(Guid categoryId, DateTime currentDate)
        {
            return _articlesRepository.GetPublishedArticleCount(categoryId, currentDate);
        }

        public IList<ArticleDto> GetPublishedArticlesByCategoryId(Guid categoryId, DateTime currentDate, int pageIndex, int pageSize)
        {
            IList<Article> articles = _articlesRepository.GetPublishedArticles(categoryId, currentDate, pageIndex, pageSize);
            List<ArticleDto> dto = _mapper.Map<List<ArticleDto>>(articles);
            return dto;
        }

        public IList<ArticleDto> GetPublishedArticles(DateTime currentDate, int pageIndex, int pageSize)
        {
            IList<Article> articles = _articlesRepository.GetPublishedArticles(currentDate, pageIndex, pageSize);
            List<ArticleDto> dto = _mapper.Map<List<ArticleDto>>(articles);
            return dto;
        }
    }
}
