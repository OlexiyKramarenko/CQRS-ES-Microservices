using Articles.ReadSide.Repository.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles.ReadSide.Repository
{
    public class ArticlesRepository : IArticlesRepository
    {
        private IMongoCollection<Category> Categories
        {
            get
            {
                return _database.GetCollection<Category>(nameof(Category).ToLower());
            }
        }
        private IMongoCollection<Article> Articles
        {
            get
            {
                return _database.GetCollection<Article>(nameof(Article).ToLower());
            }
        }
        private IMongoCollection<Comment> Comments
        {
            get
            {
                return _database.GetCollection<Comment>(nameof(Comment).ToLower());
            }
        }

        IMongoDatabase _database;
        public ArticlesRepository()
        {

        }
        public ArticlesRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public void InsertCategory(Category category)
        {
            Categories.InsertOne(category);
        }

        public void InsertArticle(Article article)
        {
            var update = Builders<Category>.Update.AddToSet(x => x.Articles, article);
            Categories.FindOneAndUpdate(x => x.Id == article.CategoryId, update);
        }

        public void ApproveArticle(Guid categoryId, Guid articleId)
        {
            var filter = Builders<Category>.Filter;

            var categoryIdAndArticleIdFilter = filter.And(
              filter.Eq(x => x.Id, categoryId.ToString()),
              filter.ElemMatch(x => x.Articles, c => c.Id == articleId.ToString()));

            var update = Builders<Category>.Update;

            var artticleApprovedSetter = update.Set(x => x.Articles[-1].Approved, true);
            Categories.UpdateOne(categoryIdAndArticleIdFilter, artticleApprovedSetter);
        }

        public void DeleteArticle(string categoryId, string articleId)
        {
            var filter = Builders<Category>.Filter.Eq(nameof(Category.Id), categoryId);

            var update = Builders<Category>.Update

                .PullFilter(nameof(Category.Articles),
                           Builders<Article>.Filter.Eq(nameof(Article.Id),
                           articleId));

            Categories.FindOneAndUpdate(filter, update);
        }

        public void DeleteCategory(Guid categoryId)
        {
            this.Categories.DeleteOneAsync(a => a.Id.Equals(categoryId));
        }

        public void DeleteComment(string categoryId, string commentId)
        {
            var filter =
                Builders<Category>.Filter
                                  .Eq(item => item.Id, categoryId);

            string field = $"{nameof(Category.Articles)}.$[].{nameof(Article.Comments)}";
            var update =
                Builders<Category>.Update
                                  .PullFilter(field,
                                              Builders<Comment>.Filter
                                                               .Eq(nameof(Comment.Id), commentId));

            Categories.FindOneAndUpdate(filter, update);
        }

        public void InsertComment(string categoryId, string articleId, Comment comment)
        {
            var filter =
                Builders<Category>.Filter
                                  .And(Builders<Category>.Filter.Where(x => x.Id == categoryId),
                                       Builders<Category>.Filter.Eq("Articles.Id", articleId));

            var update =
                Builders<Category>.Update
                                  .Push($"{nameof(Category.Articles)}.$.{nameof(Article.Comments)}", comment);

            Categories.FindOneAndUpdate(filter, update);
        }

        public string GetArticleBody(string categoryId, string articleId)
        {
            var filter = new BsonDocument("$and", new BsonArray {
                new BsonDocument("CategoryId", categoryId),
                new BsonDocument("ArticleId", articleId)
            });

            return Articles.Find(filter).FirstOrDefault()?.Body;
        }

        public int GetArticleCount()
        {
            return (int)Articles.Count(new BsonDocument());
        }

        public int GetArticleCount(Guid categoryId)
        {
            var filter = Builders<Article>
                   .Filter
                   .Eq(c => c.CategoryId, categoryId.ToString());

            int count = (int)this.Articles
                                 .Count(filter);
            return count;
        }

        public int GetCommentCount(Guid articleId)
        {
            var filter = Builders<Comment>
                   .Filter
                   .Eq(c => c.ArticleId, articleId.ToString());

            int count = (int)this.Comments
                                 .Count(filter);
            return count;
        }

        public int GetCommentCount()
        {
            int count = (int)this.Comments
                                 .Count(FilterDefinition<Comment>.Empty);
            return count;
        }

        public int GetPublishedArticleCount(DateTime currentDate)
        {
            var filter = Builders<Article>.Filter.Eq(a => a.Approved, true) &
                         Builders<Article>.Filter.Lt(a => a.ReleaseDate, new BsonDateTime(currentDate));

            int count = (int)this.Articles
                                 .Count(filter);
            return count;
        }

        public int GetPublishedArticleCount(Guid categoryId, DateTime currentDate)
        {
            var filter = Builders<Article>.Filter.Eq(a => a.CategoryId, categoryId.ToString()) &
                         Builders<Article>.Filter.Lt(a => a.ReleaseDate, new BsonDateTime(currentDate));

            int count = (int)this.Articles
                                 .Count(filter);
            return count;
        }

        public void IncrementArticleViewCount(Guid articleId)
        {
            var filter = Builders<Article>.Filter.Eq("_id", articleId.ToString());
            var update = new BsonDocument("$inc", new BsonDocument(nameof(Article.ViewCount), 1));

            this.Articles.UpdateOneAsync(filter, update);
        }

        public void RateArticle(Guid articleId, int rating)
        {
            var filter = Builders<BsonDocument>
                .Filter
                .Eq("_id", articleId.ToString());

            var update = Builders<BsonDocument>
                .Update
                .Set("$inc", new BsonDocument(nameof(Article.Votes), 1))
                .Set("$inc", new BsonDocument(nameof(Article.TotalRating), rating));

            _database.GetCollection<BsonDocument>("Articles")
                     .UpdateOneAsync(filter, update);
        }

        public Article GetArticleById(Guid articleId)
        {
            var filter = Builders<Article>
                   .Filter
                   .Eq(c => c.Id, articleId.ToString());

            return this.Articles
                       .Find(filter)
                       .FirstOrDefault();
        }

        public IList<Article> GetArticles(int pageIndex, int pageSize)
        {
            int skip = (pageIndex - 1) * pageSize;
            List<Article> articles = this.Articles
                                         .Find(FilterDefinition<Article>.Empty)
                                         .Skip(skip)
                                         .Limit(pageSize)
                                         .ToList();
            return articles;
        }

        public IList<Article> GetArticles(Guid categoryId, int pageIndex, int pageSize)
        {
            var filter = Builders<Article>.Filter
                                          .Eq(c => c.CategoryId, categoryId.ToString());

            int skipCount = (pageIndex - 1) * pageSize;

            List<Article> articles = this.Articles
                                         .Find(FilterDefinition<Article>.Empty)
                                         .Skip(skipCount)
                                         .Limit(pageSize)
                                         .ToList();
            return articles;
        }

        public IList<Category> GetCategories()
        {
            List<Category> categories = this.Categories
                                            .Find(FilterDefinition<Category>.Empty)
                                            .ToList();
            return categories;
        }

        public IList<Category> GetCategories(int pageSize, int pageIndex)
        {
            int skipCount = (pageIndex - 1) * pageSize;

            List<Category> categories = this.Categories
                                            .Find(FilterDefinition<Category>.Empty)
                                            .Skip(skipCount)
                                            .Limit(pageSize)
                                            .ToList();
            return categories;
        }

        public Category GetCategoryById(Guid categoryId)
        {
            var filter = Builders<Category>
                  .Filter
                  .Eq(c => c.Id, categoryId.ToString());

            return this.Categories
                       .Find(filter)
                       .FirstOrDefault();
        }

        public Comment GetCommentById(Guid commentId)
        {
            var filter = Builders<Comment>
                   .Filter
                   .Eq(c => c.Id, commentId.ToString());

            return this.Comments
                       .Find(filter)
                       .FirstOrDefault();
        }

        public IList<Comment> GetComments(int pageIndex, int pageSize)
        {
            int skipCount = (pageIndex - 1) * pageSize;

            List<Comment> categories = this.Comments
                                            .Find(FilterDefinition<Comment>.Empty)
                                            .Skip(skipCount)
                                            .Limit(pageSize)
                                            .ToList();
            return categories;
        }

        public IList<Comment> GetComments(Guid articleId, int pageIndex, int pageSize)
        {
            var filter = Builders<Comment>
                .Filter                                          
                .Eq(c => c.ArticleId, articleId.ToString());

            int skipCount = (pageIndex - 1) * pageSize;

            List<Comment> comments = this.Comments
                                         .Find(filter)
                                         .Skip(skipCount)
                                         .Limit(pageSize)
                                         .ToList();
            return comments;
        }

        public IList<Article> GetPublishedArticles(Guid categoryId, DateTime currentDate, int pageIndex, int pageSize)
        {
            var filter = Builders<Article>.Filter.Eq(a => a.CategoryId, categoryId.ToString()) &
                         Builders<Article>.Filter.Lt(a => a.ReleaseDate, new BsonDateTime(currentDate));

            int skipCount = (pageIndex - 1) * pageSize;

            List<Article> articles = this.Articles
                                         .Find(filter)
                                         .Skip(skipCount)
                                         .Limit(pageSize)
                                         .ToList();
            return articles;
        }

        public IList<Article> GetPublishedArticles(DateTime currentDate, int pageIndex, int pageSize)
        {
            var filter = Builders<Article>
                .Filter
                .Lt(a => a.ReleaseDate, new BsonDateTime(currentDate));

            int skipCount = (pageIndex - 1) * pageSize;

            List<Article> articles = this.Articles
                                         .Find(filter)
                                         .Skip(skipCount)
                                         .Limit(pageSize)
                                         .ToList();
            return articles;
        }

        public void UpdateArticle(Article article)
        {
            var filter = Builders<Article>
                .Filter
                .Eq(c => c.Id, article.Id);

            var update = Builders<Article>
                .Update
                .Set(x => x.CategoryId, article.CategoryId)
                .Set(x => x.Title, article.Title)
                .Set(x => x.Abstract, article.Abstract)
                .Set(x => x.Body, article.Body)
                .Set(x => x.Country, article.Country)
                .Set(x => x.City, article.City)
                .Set(x => x.ReleaseDate, article.ReleaseDate)
                .Set(x => x.ExpireDate, article.ExpireDate)
                .Set(x => x.Approved, article.Approved)
                .Set(x => x.Listed, article.Listed)
                .Set(x => x.CommentsEnabled, article.CommentsEnabled)
                .Set(x => x.OnlyForMembers, article.OnlyForMembers);

            this.Articles.UpdateOneAsync(filter, update);
        }

        public void UpdateCategory(Category category)
        {
            var filter = Builders<Category>
                .Filter
                .Eq(c => c.Id, category.Id);

            var update = Builders<Category>
                .Update
                .Set(x => x.Title, category.Title)
                .Set(x => x.AddedBy, category.AddedBy)
                .Set(x => x.AddedDate, category.AddedDate)
                .Set(x => x.Description, category.Description)
                .Set(x => x.ImageUrl, category.ImageUrl)
                .Set(x => x.Importance, category.Importance);

            this.Categories.UpdateOneAsync(filter, update);
        }

        public void UpdateComment(Comment category)
        {
            var filter = Builders<Comment>
                .Filter
                .Eq(c => c.Id, category.Id);

            var update = Builders<Comment>
                .Update
                .Set(x => x.AddedBy, category.AddedBy)
                .Set(x => x.AddedByEmail, category.AddedByEmail)
                .Set(x => x.AddedByIp, category.AddedByIp)
                .Set(x => x.AddedDate, category.AddedDate)
                .Set(x => x.Body, category.Body)
                .Set(x => x.ArticleId, category.ArticleId);

            this.Comments.UpdateOneAsync(filter, update);
        }
    }
}
