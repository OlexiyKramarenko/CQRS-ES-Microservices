
using Articles.WriteSide.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Utils;
using Web.Models.Articles;

namespace Web.Controllers
{
    [Route("api/v1/admin")]
    public class ManageArticlesController : Controller
    {
        private IMapper _mapper;
        private ArticlesServiceClient _articlesService;

        public ManageArticlesController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        #region Articles

        [HttpGet]
        [Route("categories/{categoryId:guid}/articles")]
        public async Task<IActionResult> GetArticles(Guid categoryId)
        {
            ArticleDto[] dto = await _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 10);
            var model = _mapper.Map<ArticleItemViewModel[]>(dto);
            return Ok(model);
        }

        [HttpGet]
        [Route("articles/{articleId:guid}")]
        public async Task<IActionResult> DeleteArticle(Guid articleId)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IDeleteArticleCommand>(new
            {
                Id = articleId
            });
            return Ok();
        }

        [HttpPost]
        [Route("articles")]
        public IActionResult InsertArticle(AddArticleViewModel model)
        {
            return Ok(model);
        }

        [HttpGet]
        [Route("articles/{articleId:guid}")]
        public async Task<IActionResult> GetArticle(Guid articleId)
        {
            ArticleDto dto = await _articlesService.GetArticleByIdAsync(articleId);
            var model = _mapper.Map<EditArticleViewModel>(dto);
            return Ok(model);
        }

        [HttpPut]
        [Route("articles/{articleId:guid}")]
        public async Task<IActionResult> UpdateArticle(Guid articleId, [FromBody]EditArticleViewModel model)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IUpdateArticleCommand>(new
            {
                model.Id,
                model.Body
            });
            return Ok();
        }
        #endregion

        #region Categories
        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            CategoryDto[] dto = await _articlesService.GetCategoriesAsync();
            CategoryItemViewModel[] model = _mapper.Map<CategoryItemViewModel[]>(dto);
            return Ok(model);
        }

        [HttpGet]
        [Route("categories/{categoryId:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IDeleteArticleCommand>(new
            {
                Id = categoryId
            });
            return Ok();
        }

        [HttpPost]
        [Route("categories")]
        public async Task<IActionResult> InsertCategory(AddCategoryViewModel model)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IInsertCategoryCommand>(new
            {
                model.Description,
                model.ImageUrl,
                model.Importance,
                model.Title
            });
            return Ok();
        }

        [HttpGet]
        [Route("categories/{categoryId:guid}")]
        public async Task<IActionResult> FindCategory(Guid categoryId)
        {
            CategoryDto dto = await _articlesService.GetCategoryByIdAsync(categoryId);
            var model = _mapper.Map<EditCategoryViewModel>(dto);
            return Ok(model);
        }

        [HttpPut]
        [Route("categories/{categoryId:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, EditCategoryViewModel model)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IUpdateCategoryCommand>(new
            {
                model.Id,
                model.Description,
                model.ImageUrl,
                model.Importance,
                model.Title

            });
            return Ok();
        }
        #endregion

        #region Comments

        [HttpGet]
        [Route("articles/{articleId:guid}/comments")]
        public async Task<IActionResult> GetComments(Guid articleId)
        {
            CommentDto[] dto = await _articlesService.GetCommentsByArticleIdAsync(articleId, 1, 20);
            var model = _mapper.Map<ManageCommentItemViewModel[]>(dto);
            return Ok(model);
        }

        [HttpGet]
        [Route("comments/{commentId:guid}")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IDeleteCommentCommand>(new
            {
                Id = commentId
            });
            return Ok();
        }

        [HttpGet]
        [Route("comments/{commentId:guid}")]
        public async Task<IActionResult> GetComment(Guid commentId)
        {
            CommentDto dto = await _articlesService.GetCommentByIdAsync(commentId);
            var model = _mapper.Map<EditCommentViewModel>(dto);
            return Ok(model);
        }

        [HttpPut]
        [Route("comments/{commentId:guid}")]
        public async Task<IActionResult> UpdateComment(Guid commentId, EditCommentViewModel model)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IUpdateCommentCommand>(new
            {
                model.Id,
                model.AddedBy,
                model.AddedDate,
                model.Comment,
                model.UserIp
            });
            return Ok();
        }

        #endregion

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
