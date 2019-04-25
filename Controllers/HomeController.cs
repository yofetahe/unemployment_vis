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
         [HttpGet("")]
        public IActionResult Home()
        {
            return View();
        }

        [HttpGet("main")]
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet("CountyPerState/{State}")]
        public IActionResult CountyPerState(string State)
        {

            var list = dbContext.UnemploymentStats
            .Where(u => u.State == State)
            .OrderBy(u => u.County)
            .ThenBy(u => u.Year)
            .Take(100)
            .ToList();
            
            return View(list);
        }

        [HttpGet("map/{year}")]
        public IActionResult getMap(int year)
        {
            var list = dbContext.UnemploymentStats
                .Where(u => u.Year == year)
                .OrderBy(y => y.StateCode)
                .ToList();
            
            return View("UnemploymentPerState", list);
        }
    }
}
