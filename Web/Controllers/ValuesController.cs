using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Articles.WriteSide.Commands;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Server.Controllers;
using Utils;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {


        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            //var bus = BusConfigurator.ConfigureBus();
            //var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + $"{RabbitMqConstants.ArticleWriteServiceQueue}");
            //var endPoint = await bus.GetSendEndpoint(sendToUri);
            //var endPoint = await GetEndPointAsync();
            //await endPoint.Send<IInsertCommentCommand>(new
            //{
            //    AddedBy = "Ukraine"
            //});

            var endPoint = await BusConfigurator.GetEndPointAsync(RabbitMqConstants.ArticleWriteServiceQueue);

            await endPoint.Send<IInsertCommentCommand>(new
            {
                AddedBy = "Ukraine22"
            });

            //await endPoint.Send<IInsertArticleCommand>(new
            //{
            //    Country = "Ukraine"
            //});

            //await endPoint.Send<IInsertCategoryCommand>(new
            //{
            //    Description = "Some description..."
            //});

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get2(int id)
        {
            return Ok();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
