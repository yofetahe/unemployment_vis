using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        
        [HttpGet("state/{id}")]
        public IActionResult Index(int id)
        {
            var list = dbContext.UnemploymentStats
            .Where(u => u.StateCode == id)
            .OrderByDescending(u => u.ManPowerForce)
            .Take(100)
            .ToList();
            System.Console.WriteLine(list.Count);

            return View(list);
        }

    }
}
