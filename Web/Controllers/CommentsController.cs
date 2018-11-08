using Articles.WriteSide.Commands;
using AutoMapper;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System;
using System.Threading.Tasks;
using Utils;
using Web.Models.Articles;

namespace Server.Controllers
{
    [Route("api/v1/comments")]
    public class CommentsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IArticlesService _articlesService;
        private readonly ILog _logger;

        public CommentsController(IMapper mapper, IArticlesService articlesService, ILog logger)
            : base(logger)
        {
            _mapper = mapper;
            _articlesService = articlesService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> LeaveCommentAsync([FromBody] CommentDetailsViewModel model)
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

                await endPoint.Send<IInsertCommentCommand>(new
                {
                    model.AddedBy,
                    model.AddedByEmail,
                    model.ArticleId,
                    model.CategoryId,
                    model.Body
                });

                return Accepted();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}