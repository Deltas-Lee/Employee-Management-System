using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORGANISATION_X.Controllers
{
    public class DataAnalyticsController : Controller
    {
        [Authorize(Policy = "readonlypolicy")]
        public IActionResult Index()
        {
            return View();
        }

        /*public IActionResult sqlMethod()
        {
            Organisation_DB _context = new Organisation_DB();

            var sqlQuery = _context.Employees.JobRole
                .GroupBy(g => g.Employees.Gender)
                .selext(g => new(nameof g.key, count = g.count()));
            return View();
        }*/
    }
}
