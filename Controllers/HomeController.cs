using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using our_project.Models;

namespace our_project.Controllers
{
    public class HomeController : Controller
    {

        private UnemploymentContext dbContext;

        public HomeController(UnemploymentContext context)
        {
            dbContext = context;
        }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            List<UnemploymentStat> list = dbContext.UnemploymentStats.ToList();
            System.Console.WriteLine(list.Count);
            
            return View(list);
        }

    }
}
