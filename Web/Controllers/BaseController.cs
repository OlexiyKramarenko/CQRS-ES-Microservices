using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Server.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILog _log;

        public BaseController(ILog log)
        {
            _log = log;
        }

        protected IActionResult InternalServerError(Exception ex)
        {
            _log.Info(ex.Message);

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
