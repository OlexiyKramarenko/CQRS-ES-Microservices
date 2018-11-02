using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Web.Models.Articles;

namespace Web.Controllers
{
    [Route("api/v1/articles")]
    public class ArticlesController : BaseController
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
            try
            {
                ArticleDto dto = await _articlesService.GetArticleByIdAsync(articleId);

                if (dto == null)
                {
                    return NotFound();
                }

                var response = _mapper.Map<ShowArticleViewModel>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{articleId:guid}/comments")]
        public async Task<IActionResult> GetComments(Guid articleId)
        {
            try
            {
                CommentDto[] dto = await _articlesService.GetCommentsByArticleIdAsync(articleId, 1, 20);

                var response = _mapper.Map<ManageCommentItemViewModel[]>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
