using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Data;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditPage(string title)
        {
            // SELECT * FROM Pages WHERE Title = {title}
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == title);

            if (page == null)
            {
                page = new Page();
                page.Title = title;

                _dbContext.Pages.Add(page);
                _dbContext.SaveChanges();
            }

            return View(page);
        }

        [HttpPost]
        public IActionResult SavePage(string title, string content)
        {
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == title);

            if (page == null)
            {
                return View("Error");
            }

            page.Content = content;
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
