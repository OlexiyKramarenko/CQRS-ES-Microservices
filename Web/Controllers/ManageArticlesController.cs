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
    [Route("api/v1/admin/articles")]
    public class ManageArticlesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ArticlesServiceClient _articlesService;

        public ManageArticlesController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        [HttpGet]
        [Route("{articleId:guid}")]
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
        public IActionResult InsertArticle(AddArticleViewModel model)
        {
            return Ok(model);
        }

        [HttpGet]
        [Route("{articleId:guid}")]
        public async Task<IActionResult> FindArticle(Guid articleId)
        {
            ArticleDto dto = await _articlesService.GetArticleByIdAsync(articleId);
            var model = _mapper.Map<EditArticleViewModel>(dto);
            return Ok(model);
        }

        [HttpPut]
        [Route("{articleId:guid}")]
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
    }
}
