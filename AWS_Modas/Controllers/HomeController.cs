using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AWS_Modas.Models;
using AWS_Modas.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AWS_Modas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _eventRepo;

        private readonly int PageSize = 20;

        public HomeController(ILogger<HomeController> logger, IEventRepository eventRepo)
        {
            _logger = logger;
            _eventRepo = eventRepo;
        }

        public IActionResult Index(int page = 1)
        {
            ViewData.Add("Page", page);
            var lPage = _eventRepo.Events.Count() / (decimal) PageSize;
            ViewData.Add("LastPage", decimal.Ceiling(lPage));
            return View(_eventRepo.Events.Include(e => e.Location).
                                   OrderBy(e => e.TimeStamp).
                                   Skip((page - 1) * PageSize).Take(PageSize));
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
                                                 { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}