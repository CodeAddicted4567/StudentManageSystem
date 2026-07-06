using StudentMng.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using StudentMng.Contracts;
using StudentMng.Models;

namespace StudentMng.Areas.Users.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IStudentServices service;
        public DashboardController(IStudentServices _service)
        {
            service = _service;
        }
        // GET: Users/Dashboard
        public ActionResult Index()
        {
            return View();
        }
        //filters are used to here 
        [CustomAuth(Role = "Admin")]
        public ActionResult AdminProfile()
        {
            return RedirectToAction("Index","Student");
        }
        [CustomAuth(Role = "User")]
        public ActionResult UserProfile()
        {
            return RedirectToAction("UserDashboard","Dashboard",new { area = "Users" });
        }

        public async Task<ActionResult> UserDashboard()
        {
            StudentVM studentVM = new StudentVM
            {
                Students = await service.GetAllStudentsAsync()
            };
            return View(studentVM);
        }
        public async Task<ActionResult> StudentInformation(int id)
        {
            var data = await service.GetStudentByIdAsync(id);
            return View(data);
        }

        // AJAX endpoint: returns only the table partial for quick updates
        [HttpGet]
        public async Task<ActionResult> SearchStudents(string searches)
        {
            var students = await service.SearchByName(searches);

            return PartialView("_StudentData",students);
        }
        [HttpGet]
        public async Task<ActionResult> SortStudents(string sortOrder)
        {
            var students = await service.SortStudent(sortOrder);

            return PartialView("_StudentData",students);
        }
    }
}