using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using EmployeeManagement.Models;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        public EmployeeController(){}

        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEmployees()
        {
            List<Employee> oEmployeesList = new List<Employee>();

            using (AppDbContext db = new AppDbContext())
            {
                oEmployeesList = (from e in db.Employees
                                  select e).ToList();
            }

            return Json(new { data = oEmployeesList }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEmployeeById(int id)
        {
            Employee oEmployee = new Employee();

            using (AppDbContext db = new AppDbContext())
            {

                oEmployee = (from p in db.Employees.Where(x => x.Id == id)
                            select p).FirstOrDefault();
            }

            return Json(oEmployee, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddEmployee(Employee oEmployee)
        {

            bool respuesta = true;
            try
            {

                using (AppDbContext db = new AppDbContext())
                {
                    db.Employees.Add(oEmployee);
                    db.SaveChanges();
                }
            }
            catch
            {
                respuesta = false;

            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult UpdateEmployee(Employee oEmployee)
        {

            bool respuesta = true;
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Employee temp = (from p in db.Employees
                                     where p.Id == oEmployee.Id
                                     select p).FirstOrDefault();

                    temp.Name = oEmployee.Name;
                    temp.Office = oEmployee.Office;
                    temp.Position = oEmployee.Position;
                    temp.Salary = oEmployee.Salary;

                    db.SaveChanges();
                }
            }
            catch
            {
                respuesta = false;

            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteEmployee(int id)
        {
            bool respuesta = true;
            try
            {
                using (AppDbContext db = new AppDbContext())
                {
                    Employee oEmployee = new Employee();
                    oEmployee = (from p in db.Employees.Where(x => x.Id == id)
                                select p).FirstOrDefault();

                    db.Employees.Remove(oEmployee);

                    db.SaveChanges();
                }
            }
            catch
            {
                respuesta = false;
            }

            return Json(new { resultado = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}