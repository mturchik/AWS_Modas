using System.Collections.Generic;
using AWS_Modas.Models;
using AWS_Modas.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace AWS_Modas.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventRepository _eventRepo;

        private const int PageSize = 10;

        public HomeController(IEventRepository eventRepo) => _eventRepo = eventRepo;

        public IActionResult Index(int page = 1)
        {
            ViewData.Add("pageNo", page);
            var lastPage = _eventRepo.Events.Count() / (decimal) PageSize;
            ViewData.Add("lastPage", (int) decimal.Ceiling(lastPage));
            return View(_eventRepo.Events
                .Include(e => e.Location)
                .OrderBy(e => e.TimeStamp)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel
            {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}