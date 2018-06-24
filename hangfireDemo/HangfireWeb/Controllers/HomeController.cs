using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HangfireWeb.Models;
using Microsoft.Extensions.Logging;
using HangfireWeb.Services;
using Hangfire;

namespace HangfireWeb.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> _logger;
        public HomeController(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HomeController>();
        }
        public IActionResult Index()
        {
            _logger.LogInformation("start index");
            BackgroundJob.Enqueue<ICheckService>(c => c.Check());
            return View();
        }

    }
}
