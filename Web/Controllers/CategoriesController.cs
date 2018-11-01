using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Web.Models.Articles;

namespace Server.Controllers
{
    [Route("api/v1/categories")]
    public class CategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ArticlesServiceClient _articlesService;

        public CategoriesController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        [HttpGet]
        [Route("{categoryId:guid}/articles")]
        public async Task<IActionResult> GetArticles(Guid categoryId)
        {
            ArticleDto[] dto = await _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 20);
            var model = _mapper.Map<BrowseArticlesViewModel[]>(dto);
            return Ok(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            CategoryDto[] dto = await _articlesService.GetCategoriesAsync();
            var model = _mapper.Map<CategoryItemViewModel[]>(dto);
            return Ok(model);
        }
    }
}