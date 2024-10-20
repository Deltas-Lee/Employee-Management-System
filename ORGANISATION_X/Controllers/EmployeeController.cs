using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORGANISATION_X.Models;

namespace ORGANISATION_X.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly OrganisationXDB_2022ScriptContext _context;

        public EmployeeController(OrganisationXDB_2022ScriptContext context)
        {
            _context = context;
        }

        // GET: Employee
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeesTbl.ToListAsync());
        }

        [HttpGet]
        [Authorize(Policy = "writepolicy")]
        public async Task<IActionResult> Index(string SearchFunction)
        {
            ViewData["Getemployeedetails"] = SearchFunction;
            var sqlQuery = from x in _context.EmployeesTbl select x;
            if (!String.IsNullOrEmpty(SearchFunction))
            {
                sqlQuery = sqlQuery.Where(x => x.Department.Contains(SearchFunction) || x.EmployeeNumber.Equals(SearchFunction));
            }
            return View(await sqlQuery.AsNoTracking().ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesTbl = await _context.EmployeesTbl
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employeesTbl == null)
            {
                return NotFound();
            }

            return View(employeesTbl);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] EmployeesTbl employeesTbl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeesTbl);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeesTbl);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesTbl = await _context.EmployeesTbl.FindAsync(id);
            if (employeesTbl == null)
            {
                return NotFound();
            }
            return View(employeesTbl);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Age,Attrition,BusinessTravel,DailyRate,Department,DistanceFromHome,Education,EducationField,EmployeeCount,EmployeeNumber,EnvironmentSatisfaction,Gender,HourlyRate,JobInvolvement,JobLevel,JobRole,JobSatisfaction,MaritalStatus,MonthlyIncome,MonthlyRate,NumCompaniesWorked,Over18,OverTime,PercentSalaryHike,PerformanceRating,RelationshipSatisfaction,StandardHours,StockOptionLevel,TotalWorkingYears,TrainingTimesLastYear,WorkLifeBalance,YearsAtCompany,YearsInCurrentRole,YearsSinceLastPromotion,YearsWithCurrManager")] EmployeesTbl employeesTbl)
        {
            if (id != employeesTbl.EmployeeNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeesTbl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesTblExists(employeesTbl.EmployeeNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employeesTbl);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeesTbl = await _context.EmployeesTbl
                .FirstOrDefaultAsync(m => m.EmployeeNumber == id);
            if (employeesTbl == null)
            {
                return NotFound();
            }

            return View(employeesTbl);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var employeesTbl = await _context.EmployeesTbl.FindAsync(id);
            _context.EmployeesTbl.Remove(employeesTbl);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeesTblExists(string id)
        {
            return _context.EmployeesTbl.Any(e => e.EmployeeNumber == id);
        }
    }
}
