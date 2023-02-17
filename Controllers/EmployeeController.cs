using Dapper;
using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(EmployeeDapperORM.ReturnList<Employee>("EmployeeViewAll"));
        }

        [HttpGet]
        public ActionResult AddOrEdit(int  id = 0)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@id", id);
                return View(EmployeeDapperORM.ReturnList<Employee>("EmployeeViewById", param).FirstOrDefault<Employee>());
            }
           
        }


        [HttpPost]
        public ActionResult AddOrEdit(Employee employee)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", employee.Id);
            param.Add("@EmailAddress", employee.EmailAddress);
            param.Add("@FirstName", employee.FirstName);
            param.Add("@LastName", employee.LastName);
            param.Add("@ContactNumber", employee.ContactNumber);
            param.Add("@Designation", employee.Designation);

            EmployeeDapperORM.ExecuteWithoutReturnScalar("EmployeeAddOrEdit", param);

            return RedirectToAction("Index");
        }

        public ActionResult Delete (int id)
        {
            DynamicParameters param = new DynamicParameters();

            param.Add("@Id", id);

            EmployeeDapperORM.ExecuteWithoutReturnScalar("EmployeeDeleteById", param);

            return RedirectToAction("Index");


        }
    }
}