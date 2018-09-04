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
    [Route("api/[controller]/[action]")]
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
        public IActionResult BrowseArticles(Guid categoryId)
        {
            ArticleDto[] dto = _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 20).Result;
            var model = _mapper.Map<BrowseArticlesViewModel[]>(dto);
            return Ok(model); 
        }

        [HttpGet]
        public IActionResult ShowArticle(Guid id)
        {
            ArticleDto dto = _articlesService.GetArticleByIdAsync(id).Result;
            var model = _mapper.Map<ShowArticleViewModel>(dto); 
            return Ok(model);
        }
         
        [HttpGet]
        public IActionResult ShowCategories()
        { 
            CategoryDto[] dto = _articlesService.GetCategoriesAsync().Result;
            var model = _mapper.Map<CategoryItemViewModel[]>(dto); 
            return Ok(model);

        }

        [HttpPost]
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
