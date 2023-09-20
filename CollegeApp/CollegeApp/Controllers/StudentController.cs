using CollegeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CollegeApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        public IActionResult Index()
        {
            var model = _studentRepo.GetAllStudents();
            return View(model);

        }

        public ViewResult Details(int id)
        {
            Student student = _studentRepo.GetStudent(id);
            if (student == null)
            {
                Response.StatusCode = 404;
                return View("studentNotFound", id);
            }
            return View(student);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                Student newStudent = _studentRepo.Add(student);
                return RedirectToAction("details", new { id = newStudent.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int Id)
        {
            Student student = _studentRepo.GetStudent(Id);
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                Student student = _studentRepo.GetStudent(model.Id);
                student.Name = model.Name;
                student.Email = model.Email;

                Student UpdatedStudent = _studentRepo.Update(student);

                return RedirectToAction("index");

            }
            return View(model); //*
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Student student = _studentRepo.GetStudent(Id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var student = _studentRepo.GetStudent(Id);
            _studentRepo.Delete(student.Id);

            return RedirectToAction("index");
        }

    }
}

