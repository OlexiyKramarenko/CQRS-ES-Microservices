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
    [Route("api/v1")]
    public class ArticlesController : Controller
    {
        private IMapper _mapper;
        private ArticlesServiceClient _articlesService;

        public ArticlesController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        [HttpGet]
        [Route("categories/{categoryId:guid}/articles")]
        public async Task<IActionResult> GetArticles(Guid categoryId)
        {
            ArticleDto[] dto = await _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 20);
            var model = _mapper.Map<BrowseArticlesViewModel[]>(dto);
            return Ok(model);
        }

        [HttpGet]
        [Route("articles/{articleId:guid}")]
        public async Task<IActionResult> FindArticle(Guid articleId)
        {
            ArticleDto dto = await _articlesService.GetArticleByIdAsync(articleId);
            var model = _mapper.Map<ShowArticleViewModel>(dto);
            return Ok(model);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            CategoryDto[] dto = await _articlesService.GetCategoriesAsync();
            var model = _mapper.Map<CategoryItemViewModel[]>(dto);
            return Ok(model);

        }

        [HttpPost]
        [Route("comments")]
        public async Task<IActionResult> LeaveCommentAsync([FromBody] CommentDetailsViewModel model)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);

            await endPoint.Send<IInsertCommentCommand>(new
            {
                model.AddedBy,
                model.AddedByEmail,
                model.ArticleId,
                model.CategoryId,
                model.Body
            });

            return Ok();
        }
    }
}
