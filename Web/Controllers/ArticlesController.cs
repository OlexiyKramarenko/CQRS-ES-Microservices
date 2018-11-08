using AutoMapper;
using log4net;
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
        private readonly IArticlesService _articlesService;
        private readonly ILog _logger;

        public ArticlesController(IMapper mapper, IArticlesService articlesService, ILog logger)
            : base(logger)
        {
            _mapper = mapper;
            _articlesService = articlesService;
            _logger = logger;
        }

        [HttpGet("{articleId:guid}")]
        public async Task<IActionResult> FindArticleAsync(Guid articleId)
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

        [HttpGet("{articleId:guid}/comments")]
        public async Task<IActionResult> GetCommentsAsync(Guid articleId)
        {
            try
            {
                CommentDto[] dto = await _articlesService.GetCommentsByArticleIdAsync(articleId, 1, 20);

                var response = _mapper.Map<CommentItemViewModel[]>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
