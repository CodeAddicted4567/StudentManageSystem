using StudentMng.Contracts;
using StudentMng.Filters;
using StudentMng.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace StudentMng.Controllers
{
    public class StudentController : Controller //Global controller for Administration 
    {
        //Contracts are better than concrete implement 
        private readonly IStudentServices service;
        public StudentController(IStudentServices _service)
        {
            service = _service;
        }
        // GET: Student
        [LoadFilter]//this filter initiate when action method is called
        public async Task<ActionResult> Index()
        {
            try
            {
                StudentVM studentVM = new StudentVM
                {
                    Students = await service.GetAllStudentsAsync()
                };

                return View(studentVM);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error : connection failed" + e.Message);

            }
            return View();
        }

        // AJAX endpoint: returns only the table partial for quick updates
        [HttpGet]
        public async Task<ActionResult> SearchStudents(string searches)
        {
            var students = await service.SearchByName(searches);

            return PartialView("_StudentTable",
                students);
        }
        [HttpGet]
        public async Task<ActionResult> SortStudents(string sortOrder)
        {
            var students = await service.SortStudent(sortOrder);

            return PartialView("_StudentTable",
                students);
        }

        // GET: Student/Details/5
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var students = await service.GetStudentByIdAsync(id);
                if (students == null)
                {
                    return HttpNotFound();//only when click
                }
                return View(students);
            }
            catch(Exception e)
            {
                Debug.WriteLine("Error : failed to fetch data.");
                ModelState.AddModelError("Not found any records." , e.Message);
            }
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Marks")] Student stu)
        {
            if(!ModelState.IsValid)
            {
                return View(stu);// stays same page nothing happened
            }
            try
            {
                service.AddStudent(stu);
                TempData["Created"] = "Created";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                Debug.WriteLine("Error : Failed to submit data,");
                return HttpNotFound("An error occurred while submitting." + e.Message);
            }
        }

        // GET: Student/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var student = await service.GetStudentByIdAsync(id);
            if (student == null)
            {
                return HttpNotFound();//only when click
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind(Include = "Name,Marks")] Student stu)
        {
            if(!ModelState.IsValid)
            {
                return View(stu);//stays same page nothing happened
            }
            try
            {
                // TODO: Add update logic here
                var updatedStudent = await service.ModifyStudentAsync(id, stu);
                if (!updatedStudent)
                {
                    return HttpNotFound();
                }
                TempData["Modified"] = "Updated";
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return HttpNotFound("An error occurred while updating." + e.Message);
            }
        }

        // GET: Student/Delete/5
        public async Task<ActionResult> Delete(int Id)
        {
            var student = await service.GetStudentByIdAsync(Id);
            if (student == null)
            {
                return HttpNotFound();//only when click
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id,Student stu)
        {
            try
            {
                // TODO: Add delete logic here
                var student = await service.GetStudentByIdAsync(id);
                if (student==null)
                {
                    return HttpNotFound();//only when click
                }
                await service.ClearStudentsAsync(id);
                TempData["Deleted"] = "Removed";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return HttpNotFound("An error occurred while deleting." + e.Message);
            }
        }
    }
}
