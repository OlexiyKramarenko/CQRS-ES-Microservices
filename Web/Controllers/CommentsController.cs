using Articles.WriteSide.Commands;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceReference1;
using System.Threading.Tasks;
using Utils;
using Web.Models.Articles;

namespace Server.Controllers
{
    [Route("api/v1/comments")]
    public class CommentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ArticlesServiceClient _articlesService;

        public CommentsController(IMapper mapper)
        {
            _mapper = mapper;
            _articlesService = new ArticlesServiceClient();
        }

        [HttpPost]        
        public async Task<IActionResult> LeaveCommentAsync([FromBody] CommentDetailsViewModel model)
        {
            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);

            await endPoint.Send<IInsertCommentCommand>(new
            {
                model.AddedBy,
                model.AddedByEmail,
                model.ArticleId,
                model.CategoryId,
                model.Body
            });

            return Ok();
        }
    }
}