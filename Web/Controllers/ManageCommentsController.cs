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
    [Route("api/v1/admin/comments")]
    public class ManageCommentsController : Controller
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
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IDeleteCommentCommand>(new
            {
                Id = commentId
            });
            return Ok();
        }

        [HttpGet]
        [Route("{commentId:guid}")]
        public async Task<IActionResult> GetComment(Guid commentId)
        {
            CommentDto dto = await _articlesService.GetCommentByIdAsync(commentId);
            var model = _mapper.Map<EditCommentViewModel>(dto);
            return Ok(model);
        }

        [HttpPut]
        [Route("{commentId:guid}")]
        public async Task<IActionResult> UpdateComment(Guid commentId, EditCommentViewModel model)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);
            await endPoint.Send<IUpdateCommentCommand>(new
            {
                model.Id,
                model.AddedBy,
                model.AddedDate,
                model.Comment,
                model.UserIp
            });
            return Ok();
        }
    }
}