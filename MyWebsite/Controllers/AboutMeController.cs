﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Data;

namespace MyWebsite.Controllers
{
    public class AboutMeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AboutMeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var page = _dbContext.Pages.FirstOrDefault(x => x.Title == "AboutMe");
            return View(page);
        }
    }
}
