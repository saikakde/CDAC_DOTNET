using EmpWebApp.Service;
using Microsoft.AspNetCore.Mvc;
using EmpWebApp.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Mysqlx.Datatypes;
using System.Xml.Linq;

namespace EmpWebApp.Controllers
{
    public class EmpController : Controller
    {
        private IEmpService empService;
        public EmpController(IEmpService empService) {
        
            this.empService = empService;   
        }
        
        public IActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public IActionResult Add(int id, string name, string email, string phone, string address, string status, double salary) {
            Emp e = new Emp(id, name, email, phone, address, status, salary);
            empService.Add(e);
            return View();
        }
        [HttpGet]
        public IActionResult Add() {return View();}
        [HttpPost]
        public IActionResult Delete(int id) {
            empService.Deletebyid(id);
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Update(int id,string name,string email,string phone,string address,string status,double salary)
        {
            Emp emp = new Emp(id, name, email, phone, address, status, salary);
            empService.Update(emp);
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Getbyid(int id) { 
            empService.Getbyid(id);
            return View();
        }
        [HttpGet]
        public IActionResult Getbyid()
        {
            return View();
        }
        [HttpGet]
        public IActionResult All() {
         List<Emp> empList = empService.All();
            ViewData["all"] = (empList);  
            return View();
        }
        [HttpGet]
        public IActionResult sort()
        {
            List<Emp> empList = empService.Sort();
            ViewData["sort"] = (empList);
            return View();
        }


    }
}
