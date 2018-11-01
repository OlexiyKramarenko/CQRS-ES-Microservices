using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Web.Models.Articles;

namespace Web.Controllers
{
    [Route("api/v1/articles")]
    public class ArticlesController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ArticlesServiceClient _articlesService;

        public ArticlesController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        [HttpGet]
        [Route("{articleId:guid}")]
        public async Task<IActionResult> FindArticle(Guid articleId)
        {
            ArticleDto dto = await _articlesService.GetArticleByIdAsync(articleId);
            var model = _mapper.Map<ShowArticleViewModel>(dto);
            return Ok(model);
        }

        [HttpGet]
        [Route("{articleId:guid}/comments")]
        public async Task<IActionResult> GetComments(Guid articleId)
        {
            CommentDto[] dto = await _articlesService.GetCommentsByArticleIdAsync(articleId, 1, 20);
            var model = _mapper.Map<ManageCommentItemViewModel[]>(dto);
            return Ok(model);
        }
    }
}
