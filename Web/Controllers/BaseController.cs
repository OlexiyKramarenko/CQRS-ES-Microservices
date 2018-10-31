using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace Server.Controllers
{
    public class BaseController : Controller
    {
        protected async Task<ISendEndpoint> GetEndPointAsync(string destination)
        {
            var bus = BusConfigurator.ConfigureBus();
            var sendToUri = new Uri($"{RabbitMqConstants.RabbitMqUri}" + destination);
            var endPoint = await bus.GetSendEndpoint(sendToUri);
            return endPoint;
        }
    }
}