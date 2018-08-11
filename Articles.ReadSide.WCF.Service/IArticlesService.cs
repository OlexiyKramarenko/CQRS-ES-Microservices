using Articles.ReadSide.WCF.Service.DTO;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Articles.ReadSide.WCF.Service
{
    [ServiceContract]
    public interface IArticlesService
    {
        [OperationContract]
        string GetArticleBody(string categoryId, string articleId);

        [OperationContract]
        int GetArticleCount();

        [OperationContract]
        int GetArticleCountByCategoryId(Guid categoryId);

        [OperationContract]
        int GetCommentCountByArticleId(Guid articleId);

        [OperationContract]
        int GetCommentCount();

        [OperationContract]
        int GetPublishedArticleCount(DateTime currentDate);

        [OperationContract]
        int GetPublishedArticleCountByCategoryId(Guid categoryId, DateTime currentDate);

        [OperationContract]
        ArticleDto GetArticleById(Guid articleId);

        [OperationContract]
        IList<ArticleDto> GetArticles(int pageIndex, int pageSize);

        [OperationContract]
        IList<ArticleDto> GetArticlesByCategoryId(Guid categoryId, int pageIndex, int pageSize);

        [OperationContract]
        IList<CategoryDto> GetCategories();

        [OperationContract]
        IList<CategoryDto> GetCategoriesByIndex(int pageSize, int pageIndex);

        [OperationContract]
        CategoryDto GetCategoryById(Guid categoryId);

        [OperationContract]
        CommentDto GetCommentById(Guid commentId);

        [OperationContract]
        IList<CommentDto> GetComments(int pageIndex, int pageSize);

        [OperationContract]
        IList<CommentDto> GetCommentsByArticleId(Guid articleId, int pageIndex, int pageSize);

        [OperationContract]
        IList<ArticleDto> GetPublishedArticles(DateTime currentDate, int pageIndex, int pageSize);

        [OperationContract]
        IList<ArticleDto> GetPublishedArticlesByCategoryId(Guid categoryId, DateTime currentDate, int pageIndex, int pageSize);
    }
}
