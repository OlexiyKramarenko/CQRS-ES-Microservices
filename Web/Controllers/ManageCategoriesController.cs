using Articles.WriteSide.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Utils;
using Web.Models.Articles;

namespace Server.Controllers
{
    [Route("api/v1/admin/categories")]
    public class ManageCategoriesController : BaseController
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

        [HttpGet]
        [Route("{categoryId:guid}/articles")]
        public async Task<IActionResult> GetArticles(Guid categoryId)
        {
            try
            {
                ArticleDto[] dto = await _articlesService.GetArticlesByCategoryIdAsync(categoryId, 1, 10);

                var response = _mapper.Map<ArticleItemViewModel[]>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{categoryId:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            try
            {
                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IDeleteArticleCommand>(new
                {
                    Id = categoryId
                });

                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertCategory(AddCategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity);
                }

                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IInsertCategoryCommand>(new
                {
                    model.Description,
                    model.ImageUrl,
                    model.Importance,
                    model.Title
                });

                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{categoryId:guid}")]
        public async Task<IActionResult> FindCategory(Guid categoryId)
        {
            try
            {
                CategoryDto dto = await _articlesService.GetCategoryByIdAsync(categoryId);

                if (dto == null)
                {
                    return NotFound();
                }

                var response = _mapper.Map<EditCategoryViewModel>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{categoryId:guid}")]
        public async Task<IActionResult> UpdateCategory(Guid categoryId, [FromBody]EditCategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }

                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status422UnprocessableEntity);
                }

                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IUpdateCategoryCommand>(new
                {
                    categoryId,
                    model.Description,
                    model.ImageUrl,
                    model.Importance,
                    model.Title
                });

                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}