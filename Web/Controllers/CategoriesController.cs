using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Web.Models.Articles;

namespace Server.Controllers
{
    [Route("api/v1/categories")]
    public class CategoriesController : BaseController
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
            try
            {
                ArticleDto[] dto = await _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 20);

                var response = _mapper.Map<BrowseArticlesViewModel[]>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                CategoryDto[] dto = await _articlesService.GetCategoriesAsync();

                var response = _mapper.Map<CategoryItemViewModel[]>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}