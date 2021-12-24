using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDemo.DAL;
using StudentDemo.Models;
using StudentDemo.ViewModels;
using System.IO;


namespace StudentDemo.Controllers
{
    public class StudentController : Controller
    {
        public readonly AppDbContext context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public StudentController(AppDbContext _context, IWebHostEnvironment hostEnvironment)
        {
            this.context = _context;
            this._hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var data = context.students.ToList();
            var model = new List<StudentViewModel>();
            foreach (var item in data)
            {
                model.Add(new StudentViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Age = item.Age
                });
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentViewModel vm)
        {
            var data = new Student();
            data.Name = vm.Name;
            data.Age = vm.Age;
            context.students.Add(data);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var std = context.students.Find(Id);
            var vm = new StudentViewModel()
            {
                Id = std.Id,
                Age = std.Age,
                Name = std.Name,

            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, StudentViewModel vm)
        {
            var std = context.students.Find(id);
            std.Name = vm.Name;
            std.Age = vm.Age;
            context.students.Update(std);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var std = context.students.Find(Id);
            var vm = new StudentViewModel()
            {
                Id = std.Id,
                Age = std.Age,
                Name = std.Name,

            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Delete(int Id, StudentViewModel vm)
        {
            var std = context.students.Find(Id);
            std.Name = vm.Name;
            std.Age = vm.Age;
            context.students.Remove(std);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}