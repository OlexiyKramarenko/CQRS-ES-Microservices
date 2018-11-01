using Articles.WriteSide.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Utils;
using Web.Models.Articles;

namespace Server.Controllers
{
    [Route("api/v1/admin/categories")]
    public class ManageCategoriesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ArticlesServiceClient _articlesService;

        public ManageCategoriesController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            CategoryDto[] dto = await _articlesService.GetCategoriesAsync();
            CategoryItemViewModel[] model = _mapper.Map<CategoryItemViewModel[]>(dto);
            return Ok(model);
        }

        [HttpGet]
        [Route("{categoryId:guid}/articles")]
        public async Task<IActionResult> GetArticles(Guid categoryId)
        {
            ArticleDto[] dto = await _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 10);
            var model = _mapper.Map<ArticleItemViewModel[]>(dto);
            return Ok(model);
        }
        [HttpGet]
        [Route("{categoryId:guid}")]
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
        [Route("{categoryId:guid}")]
        public async Task<IActionResult> FindCategory(Guid categoryId)
        {
            CategoryDto dto = await _articlesService.GetCategoryByIdAsync(categoryId);
            var model = _mapper.Map<EditCategoryViewModel>(dto);
            return Ok(model);
        }

        [HttpPut]
        [Route("{categoryId:guid}")]
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
    }
}