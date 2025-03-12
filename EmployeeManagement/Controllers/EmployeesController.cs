using Sankalp_vraj_assignment_3.Data;
using Sankalp_vraj_assignment_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;

namespace Sankalp_vraj_assignment_3.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index()
        {
            var employees = _context.Employees.ToList();
            // Return empty list instead of null if no employees found
            if (employees == null)
            {
                employees = new List<Employee>();
            }
            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees
                .FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public IActionResult Create([Bind("FirstName,LastName,JobTitle,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, [Bind("EmployeeId,FirstName,LastName,JobTitle,Salary")] Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                }
                catch
                {
                    if (!EmployeeExists(employee.EmployeeId))
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
            return View(employee);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees
                .FirstOrDefault(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Employees/Browse
        public IActionResult Browse(int? position)
        {
            var employees = _context.Employees.ToList();
            
            if (employees == null || employees.Count == 0)
            {
                return View("Index", new List<Employee>());
            }

            int pos = position ?? 0;
            
            // Ensure position is within bounds
            if (pos < 0)
            {
                pos = 0;
            }
            else if (pos >= employees.Count)
            {
                pos = employees.Count - 1;
            }

            ViewBag.CurrentPosition = pos;
            ViewBag.TotalEmployees = employees.Count;
            ViewBag.HasPrevious = pos > 0;
            ViewBag.HasNext = pos < employees.Count - 1;

            return View(employees[pos]);
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
