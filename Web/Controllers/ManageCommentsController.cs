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
    [Route("api/v1/admin/comments")]
    public class ManageCommentsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ArticlesServiceClient _articlesService;

        public ManageCommentsController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        [HttpGet]
        [Route("{commentId:guid}")]
        public async Task<IActionResult> DeleteComment(Guid commentId)
        {
            try
            {
                var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
                await endPoint.Send<IDeleteCommentCommand>(new
                {
                    Id = commentId
                });
                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{commentId:guid}")]
        public async Task<IActionResult> FindComment(Guid commentId)
        {
            try
            {
                CommentDto dto = await _articlesService.GetCommentByIdAsync(commentId);

                if (dto == null)
                {
                    return NotFound();
                }

                var response = _mapper.Map<EditCommentViewModel>(dto);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{commentId:guid}")]
        public async Task<IActionResult> UpdateComment(Guid commentId, EditCommentViewModel model)
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
                await endPoint.Send<IUpdateCommentCommand>(new
                {
                    model.Id,
                    model.AddedBy,
                    model.AddedDate,
                    model.Comment,
                    model.UserIp
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