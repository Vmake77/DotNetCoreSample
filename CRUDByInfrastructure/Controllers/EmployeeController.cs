using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessEntity;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUDByInfrastructure.Controllers
{
    public class EmployeeController : BaseController
    {
        public EmployeeController(IEmployee employee)
        {
            this.Employee = employee;
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(Employee.GetEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View(Employee.GetEmployeeById(id));
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            try
            {
                Employee.Insert(employeeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View(Employee.GetEmployeeById(id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeModel employeeModel)
        {
            try
            {
                Employee.Update(employeeModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Employee.GetEmployeeById(id));
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}